using System.Text.Json.Serialization;

namespace BLL.Entities.Innosilicon.Response
{
    public class InnosiliconAuthenticationResult : EmptyResult
    {
        [JsonPropertyName("jwt")]
        public string? jwt { get; set; }
    }
}
