using AsicPanel.Shared.Entities;
using AsicPanel.Shared.Entities.Innosilicon;
using AsicPanel.Shared.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var uri = Path.Combine(device.Ip,InnosiliconApi.Auth);

            var values = new Dictionary<string, string>
            {
                { "username", device.Username },
                { "password", device.Password }
            };

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

            InnosiliconAuthenticationResult res;
            try
            {
                res = JsonSerializer.Deserialize<InnosiliconAuthenticationResult>(responseString);
            }
            catch
            {
                return new EmptyResult { Success = false, Message = "Ошибка: не удалось десериализовать ответ." };
            }

            Tokens.Add(device.Ip, res?.JwtToken);

            return new EmptyResult { Success = true };
        }
        
        public InnosiliconSummary GetMockSummary(Device device)
        {
            var mockSum = InnosiliconMock.mockSummary;
            var obj = JsonSerializer.Deserialize<InnosiliconSummary>(mockSum);
            return obj;
        }
    }

    public interface IInnosiliconService
    {
        public InnosiliconSummary GetMockSummary(Device device);

        public Task<EmptyResult> AuthAsync(Device device);
    }
}
