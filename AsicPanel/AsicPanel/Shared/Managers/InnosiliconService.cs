using AsicPanel.Shared.Entities;
using AsicPanel.Shared.Entities.Innosilicon;
using AsicPanel.Shared.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AsicPanel.Shared.Managers
{
    public class InnosiliconService : IInnosiliconService
    {

        private Dictionary<string,string> Tokens = new Dictionary<string,string>();
        
        public async Task<EmptyResult> AuthAsync(Device device)
        {
            var client = new HttpClient();
            var uri = device.Ip + "/" + InnosiliconApi.Auth;

            var values = new Dictionary<string, string>
            {
                { "username", device.Username },
                { "password", device.Password }
            };

            var content = new FormUrlEncodedContent(values);
            /*
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
            */
            var responseString = InnosiliconMock.mockAuth;
            InnosiliconAuthenticationResult res;
            try
            {
                res = JsonSerializer.Deserialize<InnosiliconAuthenticationResult>(responseString);
            }
            catch
            {
                return new EmptyResult { Success = false, Message = "Ошибка: не удалось десериализовать ответ." };
            }

            Tokens.Add(device.Ip, res?.jwt);

            return new EmptyResult { Success = true };
        }

        public async Task<Result<InnosiliconSummaryResult>> GetSummaryDevice(Device device)
        {
            var jwt = Tokens[device.Ip];
            if (string.IsNullOrEmpty(jwt))
            {
                //throw
            }

            /*
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);

            var uri = device.Ip + "/" + InnosiliconApi.Summary;

            var values = new Dictionary<string, string>{};

            var content = new FormUrlEncodedContent(values);

            
            HttpResponseMessage response;
            try
            {
                response = await client.PostAsync(uri, content);
            }
            catch
            {
                return new Result<InnosiliconSummary> { Success = false, Message = "Ошибка: не удалось подключиться к устройству." };
            }

            if (!response.IsSuccessStatusCode)
            {
                return new Result<InnosiliconSummary> { Success = false, Message = response.ReasonPhrase };
            }
            
            var responseString = await response.Content.ReadAsStringAsync();
            */
            var responseString = InnosiliconMock.mockSummary;
            InnosiliconSummaryResult res;
            try
            {
                res = JsonSerializer.Deserialize<InnosiliconSummaryResult>(responseString);
            }
            catch(Exception ex)
            {
                return new Result<InnosiliconSummaryResult> { Success = false, Message = "Ошибка: не удалось десериализовать ответ." };
            }

            return new Result<InnosiliconSummaryResult> { Data = res, Success = true };
        }
    }

    public interface IInnosiliconService
    {

        public Task<EmptyResult> AuthAsync(Device device);

        public Task<Result<InnosiliconSummaryResult>> GetSummaryDevice(Device device);
    }
}
