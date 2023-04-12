using BLL.Entities;
using System.Text.Json;
using BLL.Resources;
using Microsoft.Extensions.Caching.Memory;
using BLL.Entities.Innosilicon.Response;
using System.Net.Http.Headers;
using BLL.Entities.Innosilicon.Emulation;
using BLL.Logs;
using System.Net.Http;

namespace BLL.Managers
{
    public class InnosiliconService : IInnosiliconService
    {
        private static string _logFileName = "InnosiliconService";

        /// <summary>
        /// Кэш
        /// </summary>
        private IMemoryCache _cache;

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

        /// <summary>
        /// Хранилищи объектов для эмуляции
        /// </summary>
        private EmulatorStorage _emulatorStorage;

        public InnosiliconService(IMemoryCache _cache)
        {
            this._cache = _cache;
            _emulatorStorage = EmulatorStorage.Instance();
            EmulationDevieCount = 0;
        }

        /// <summary>
        /// Добавить недостающее количество эмуляторов
        /// </summary>
        /// <param name="countToAdd">Количество эмуляторов для добавления</param>
        private void AddMissingEmulator(int countToAdd)
        {
            LogRecorder.GetLogRecorder(_logFileName).Write("AddMissingEmulator start");
            for (int i = 0; i < countToAdd; i++)
            {
                InnosiliconEmulator innosiliconEmulator = new InnosiliconEmulator();
                _emulatorStorage.Add(innosiliconEmulator);
            }
            LogRecorder.GetLogRecorder(_logFileName).Write("AddMissingEmulator end");
        }

        /// <summary>
        /// Добавить недостающее количество эмуляторов асинхронно
        /// </summary>
        /// <param name="countToAdd">Количество эмуляторов для добавления</param>
        private void AddMissingEmulatorAsync(int countToAdd)
        {
            LogRecorder.GetLogRecorder(_logFileName).Write("AddMissingEmulatorAsync start");
            Task.Run(() =>
            {
                AddMissingEmulator(countToAdd);
            });
            LogRecorder.GetLogRecorder(_logFileName).Write("AddMissingEmulatorAsync end");
        }

        /// <summary>
        /// Удалить лишнее количество эмуляторов
        /// </summary>
        /// <param name="countToRemove">Количество эмуляторов для удаления</param>
        private void RemoveSuperfluousEmulator(int countToRemove)
        {
            LogRecorder.GetLogRecorder(_logFileName).Write("RemoveSuperfluousEmulator start");
            for (int i = countToRemove; i > 0; i--)
            {
                InnosiliconEmulator innosiliconEmulator = _emulatorStorage.Last();
                _cache.Remove(innosiliconEmulator.Ip);
                _emulatorStorage.Remove(innosiliconEmulator);
            }
            LogRecorder.GetLogRecorder(_logFileName).Write("RemoveSuperfluousEmulator end");
        }

        // <summary>
        /// Удалить лишнее количество эмуляторов асинхронно
        /// </summary>
        /// <param name="countToRemove">Количество эмуляторов для удаления</param>
        private void RemoveSuperfluousEmulatorAsync(int countToRemove)
        {
            LogRecorder.GetLogRecorder(_logFileName).Write("RemoveSuperfluousEmulatorAsync start");
            Task.Run(() =>
            {
                RemoveSuperfluousEmulator(countToRemove);
            });
            LogRecorder.GetLogRecorder(_logFileName).Write("RemoveSuperfluousEmulatorAsync end");
        }

        private EmptyResult Auth(Device device)
        {
            LogRecorder.GetLogRecorder(_logFileName).Write("Auth start");
            InnosiliconEmulator innosiliconEmulator = _emulatorStorage.InnosiliconEmulators.Find(x => x.Ip.Equals(device.Ip));
            if (innosiliconEmulator != null)
            {
                LogRecorder.GetLogRecorder(_logFileName).Write("Auth is emulation device");
                Thread.Sleep(3000); // эмулируем задержку как при работе с реальным оборудованием
                LogRecorder.GetLogRecorder(_logFileName).Write("Auth set match ip - jwt");
                _cache.Set(innosiliconEmulator.Ip, innosiliconEmulator.Jwt);
                LogRecorder.GetLogRecorder(_logFileName).Write("Auth end");
                return new EmptyResult { Success = true };
            }
            else
            {
                LogRecorder.GetLogRecorder(_logFileName).Write("Auth is real device");
                var client = new HttpClient();
                var uri = device.Ip + "/" + InnosiliconApi.Auth;
                //var uri = "http://192.168.0.101/api/auth";
                var values = new Dictionary<string, string> { { "username", device.Username }, { "password", device.Password } };

                var content = new FormUrlEncodedContent(values);

                HttpResponseMessage httpResponseMessage;
                try
                {
                    LogRecorder.GetLogRecorder(_logFileName).Write("Auth send auth request to device start");
                    Task<HttpResponseMessage> postTask = client.PostAsync(uri, content);
                    postTask.Start();
                    postTask.Wait();
                    httpResponseMessage = postTask.Result;
                    LogRecorder.GetLogRecorder(_logFileName).Write("Auth send auth request to device end");
                }
                catch
                {
                    LogRecorder.GetLogRecorder(_logFileName).Write("Auth send auth request to device error");
                    return new EmptyResult { Success = false, Message = "Ошибка: не удалось подключиться к устройству." };
                }

                if (!httpResponseMessage.IsSuccessStatusCode)
                {
                    LogRecorder.GetLogRecorder(_logFileName).Write(string.Format("Auth auth request response error: {0}", httpResponseMessage.ReasonPhrase));
                    return new EmptyResult { Success = false, Message = httpResponseMessage.ReasonPhrase };
                }

                LogRecorder.GetLogRecorder(_logFileName).Write("Auth read response start");
                Task<string> responseReadAsAsyncTask = httpResponseMessage.Content.ReadAsStringAsync();
                responseReadAsAsyncTask.Start();
                responseReadAsAsyncTask.Wait();
                var responseString = responseReadAsAsyncTask.Result;
                LogRecorder.GetLogRecorder(_logFileName).Write("Auth read response end");

                //var responseString = InnosiliconMock.mockAuth;
                InnosiliconAuthenticationResult res;
                try
                {
                    res = JsonSerializer.Deserialize<InnosiliconAuthenticationResult>(responseString);
                }
                catch
                {
                    LogRecorder.GetLogRecorder(_logFileName).Write("Auth response deserialize error");
                    return new EmptyResult { Success = false, Message = "Ошибка: не удалось десериализовать ответ." };
                }

                LogRecorder.GetLogRecorder(_logFileName).Write("Auth set match ip - jwt");
                _cache.Set(device.Ip, res?.jwt);

                LogRecorder.GetLogRecorder(_logFileName).Write("Auth end");
                return new EmptyResult { Success = true };
            }
        }

        public Task<EmptyResult> AuthAsync(Device device)
        {
            LogRecorder.GetLogRecorder(_logFileName).Write("AuthAsync start");
            Task<EmptyResult> authTask = new Task<EmptyResult>(() => { return Auth(device); });
            authTask.Start();
            LogRecorder.GetLogRecorder(_logFileName).Write("AuthAsync end");
            return authTask;
        }

        public Result<InnosiliconSummaryResult> GetSummaryDevice(Device device)
        {
            LogRecorder.GetLogRecorder(_logFileName).Write("GetSummaryDevice start");
            InnosiliconEmulator innosiliconEmulator = _emulatorStorage.FindByIp(device.Ip);
            if (innosiliconEmulator != null)
            {
                LogRecorder.GetLogRecorder(_logFileName).Write("GetSummaryDevice is emulation device");
                LogRecorder.GetLogRecorder(_logFileName).Write("GetSummaryDevice get summary");
                InnosiliconSummaryResult innosiliconSummaryResult = innosiliconEmulator.GetSummary();
                LogRecorder.GetLogRecorder(_logFileName).Write("GetSummaryDevice end");
                return new Result<InnosiliconSummaryResult>() { Success = true, Data = innosiliconSummaryResult };
            }
            else
            {
                var jwt = _cache.Get(device.Ip);
                if (string.IsNullOrEmpty(jwt.ToString()))
                {
                    LogRecorder.GetLogRecorder(_logFileName).Write("GetSummaryDevice jwt not found");
                    return new Result<InnosiliconSummaryResult> { Success = false, Message = "Ошибка: не удалось получить данные (не удалось получить ключ авторизации)." };
                }

                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt.ToString());

                var uri = device.Ip + "/" + InnosiliconApi.Summary;

                var values = new Dictionary<string, string> { };

                var content = new FormUrlEncodedContent(values);


                HttpResponseMessage httpResponseMessage;
                try
                {
                    LogRecorder.GetLogRecorder(_logFileName).Write("GetSummaryDevice send get summary request to device start");
                    Task<HttpResponseMessage> postTask = client.PostAsync(uri, content);
                    postTask.Start();
                    postTask.Wait();
                    httpResponseMessage = postTask.Result;
                    LogRecorder.GetLogRecorder(_logFileName).Write("GetSummaryDevice send get summary request to device end");
                }
                catch
                {
                    LogRecorder.GetLogRecorder(_logFileName).Write("GetSummaryDevice send get summary request to device error");
                    return new Result<InnosiliconSummaryResult> { Success = false, Message = "Ошибка: не удалось подключиться к устройству." };
                }

                if (!httpResponseMessage.IsSuccessStatusCode)
                {
                    LogRecorder.GetLogRecorder(_logFileName).Write(string.Format("GetSummaryDevice auth request response error: {0}", httpResponseMessage.ReasonPhrase));
                    return new Result<InnosiliconSummaryResult> { Success = false, Message = httpResponseMessage.ReasonPhrase };
                }

                LogRecorder.GetLogRecorder(_logFileName).Write("GetSummaryDevice read response start");
                Task<string> responseReadAsAsyncTask = httpResponseMessage.Content.ReadAsStringAsync();
                responseReadAsAsyncTask.Start();
                responseReadAsAsyncTask.Wait();
                var responseString = responseReadAsAsyncTask.Result;
                LogRecorder.GetLogRecorder(_logFileName).Write("GetSummaryDevice read response end");

                //var responseString = InnosiliconMock.mockSummary;
                InnosiliconSummaryResult res;
                try
                {
                    res = JsonSerializer.Deserialize<InnosiliconSummaryResult>(responseString);
                }
                catch (Exception ex)
                {
                    LogRecorder.GetLogRecorder(_logFileName).Write("GetSummaryDevice response deserialize error");
                    return new Result<InnosiliconSummaryResult> { Success = false, Message = "Ошибка: не удалось десериализовать ответ." };
                }

                LogRecorder.GetLogRecorder(_logFileName).Write("GetSummaryDevice end");
                return new Result<InnosiliconSummaryResult> { Data = res, Success = true };
            }
        }

        public Task<Result<InnosiliconSummaryResult>> GetSummaryDeviceAsync(Device device)
        {
            LogRecorder.GetLogRecorder(_logFileName).Write("GetSummaryDeviceAsync start");
            Task<Result<InnosiliconSummaryResult>> getSummaryDeviceTask = new Task<Result<InnosiliconSummaryResult>>(() => { return GetSummaryDevice(device); });
            getSummaryDeviceTask.Start();
            LogRecorder.GetLogRecorder(_logFileName).Write("GetSummaryDeviceAsync end");
            return getSummaryDeviceTask;
        }
    }

    public interface IInnosiliconService
    {
        public int EmulationDevieCount { get; set; }
        public Task<EmptyResult> AuthAsync(Device device);
        public Task<Result<InnosiliconSummaryResult>> GetSummaryDeviceAsync(Device device);
    }
}
