using BLL.Entities;
using System.Text.Json;
using BLL.Resources;
using Microsoft.Extensions.Caching.Memory;
using BLL.Entities.Innosilicon.Response;
using System.Net.Http.Headers;
using BLL.Entities.Innosilicon.Emulation;

namespace BLL.Managers
{
    public class InnosiliconService : IInnosiliconService
    {
        /// <summary>
        /// Кэш
        /// </summary>
        private IMemoryCache _cache;

        private bool _isEmulation;
        /// <summary>
        /// Флаг эмуляции работы асиков
        /// </summary>
        public bool IsEmulation
        {
            get { return _isEmulation; }
            set { _isEmulation = value; }
        }

        private int _emulationDevieCount;
        /// <summary>
        /// Количество объектов, эулирующих работу асиков
        /// </summary>
        public int EmulationDevieCount
        {
            get { return _emulationDevieCount; }
            set
            {
                _emulationDevieCount = value;
                if (_emulatorStorage.InnosiliconEmulatorCount > _emulationDevieCount)

                    RemoveSuperfluousEmulatorAsync(_emulatorStorage.InnosiliconEmulatorCount - _emulationDevieCount);
                else
                    AddMissingEmulatorAsync(_emulationDevieCount - _emulatorStorage.InnosiliconEmulatorCount);
            }
        }

        private EmulatorStorage _emulatorStorage;

        public InnosiliconService(IMemoryCache _cache)
        {
            this._cache = _cache;
            _emulatorStorage = EmulatorStorage.Instance();
            IsEmulation = false;
            EmulationDevieCount = 0;
        }

        /// <summary>
        /// Добавить недостающее количество эмуляторов
        /// </summary>
        /// <param name="countToAdd">Количество эмуляторов для добавления</param>
        private void AddMissingEmulator(int countToAdd)
        {
            for (int i = 0; i < countToAdd; i++)
            {
                InnosiliconEmulator innosiliconEmulator = new InnosiliconEmulator();
                _emulatorStorage.Add(innosiliconEmulator);
            }
        }

        /// <summary>
        /// Добавить недостающее количество эмуляторов асинхронно
        /// </summary>
        /// <param name="countToAdd">Количество эмуляторов для добавления</param>
        private void AddMissingEmulatorAsync(int countToAdd)
        {
            Task.Run(() =>
            {
                AddMissingEmulator(countToAdd);
            });
        }

        /// <summary>
        /// Удалить лишнее количество эмуляторов
        /// </summary>
        /// <param name="countToRemove">Количество эмуляторов для удаления</param>
        private void RemoveSuperfluousEmulator(int countToRemove)
        {
            for (int i = countToRemove; i > 0; i--)
            {
                InnosiliconEmulator innosiliconEmulator = _emulatorStorage.Last();
                _cache.Remove(innosiliconEmulator.Ip);
                _emulatorStorage.Remove(innosiliconEmulator);
            }
        }

        // <summary>
        /// Удалить лишнее количество эмуляторов асинхронно
        /// </summary>
        /// <param name="countToRemove">Количество эмуляторов для удаления</param>
        private void RemoveSuperfluousEmulatorAsync(int countToRemove)
        {
            Task.Run(() =>
            {
                RemoveSuperfluousEmulator(countToRemove);
            });
        }

        public async Task<EmptyResult> AuthAsync(Device device)
        {
            InnosiliconEmulator innosiliconEmulator = _emulatorStorage.InnosiliconEmulators.Find(x => x.Ip.Equals(device.Ip));
            if (innosiliconEmulator != null)
            {
                _cache.Set(innosiliconEmulator.Ip, innosiliconEmulator.Jwt);
                return new EmptyResult { Success = true };
            }
            else
            {
                var client = new HttpClient();
                var uri = device.Ip + "/" + InnosiliconApi.Auth;
                //var uri = "http://192.168.0.101/api/auth";
                var values = new Dictionary<string, string> { { "username", device.Username }, { "password", device.Password } };

                var content = new FormUrlEncodedContent(values);

                HttpResponseMessage response;
                try
                {
                    response = await client.PostAsync(uri, content);
                }
                catch
                {
                    return new EmptyResult { Success = false, Message = "Ошибка: не удалось подключиться к устройству." };
                }

                if (!response.IsSuccessStatusCode)
                {
                    return new EmptyResult { Success = false, Message = response.ReasonPhrase };
                }

                var responseString = await response.Content.ReadAsStringAsync();

                //var responseString = InnosiliconMock.mockAuth;
                InnosiliconAuthenticationResult res;
                try
                {
                    res = JsonSerializer.Deserialize<InnosiliconAuthenticationResult>(responseString);
                }
                catch
                {
                    return new EmptyResult { Success = false, Message = "Ошибка: не удалось десериализовать ответ." };
                }

                _cache.Set(device.Ip, res?.jwt);

                return new EmptyResult { Success = true };
            }
        }

        public async Task<Result<InnosiliconSummaryResult>> GetSummaryDevice(Device device)
        {
            InnosiliconEmulator innosiliconEmulator = _emulatorStorage.FindByIp(device.Ip);
            if (innosiliconEmulator != null)
            {
                return new Result<InnosiliconSummaryResult>() { Success = true, Data = innosiliconEmulator.GetSummary() };
            }
            else
            {
                var jwt = _cache.Get(device.Ip);
                if (string.IsNullOrEmpty(jwt.ToString()))
                {
                    return new Result<InnosiliconSummaryResult> { Success = false, Message = "Ошибка: не удалось получить данные." };
                }

                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt.ToString());

                var uri = device.Ip + "/" + InnosiliconApi.Summary;

                var values = new Dictionary<string, string> { };

                var content = new FormUrlEncodedContent(values);


                HttpResponseMessage response;
                try
                {
                    response = await client.PostAsync(uri, content);
                }
                catch
                {
                    return new Result<InnosiliconSummaryResult> { Success = false, Message = "Ошибка: не удалось подключиться к устройству." };
                }

                if (!response.IsSuccessStatusCode)
                {
                    return new Result<InnosiliconSummaryResult> { Success = false, Message = response.ReasonPhrase };
                }

                var responseString = await response.Content.ReadAsStringAsync();

                //var responseString = InnosiliconMock.mockSummary;
                InnosiliconSummaryResult res;
                try
                {
                    res = JsonSerializer.Deserialize<InnosiliconSummaryResult>(responseString);
                }
                catch (Exception ex)
                {
                    return new Result<InnosiliconSummaryResult> { Success = false, Message = "Ошибка: не удалось десериализовать ответ." };
                }

                return new Result<InnosiliconSummaryResult> { Data = res, Success = true };
            }
        }
    }

    public interface IInnosiliconService
    {
        public bool IsEmulation { get; set; }
        public int EmulationDevieCount { get; set; }
        public Task<EmptyResult> AuthAsync(Device device);
        public Task<Result<InnosiliconSummaryResult>> GetSummaryDevice(Device device);
    }
}
