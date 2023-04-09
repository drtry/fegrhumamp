using System.Text.Json.Serialization;

namespace BLL.Entities.Innosilicon
{
    public class InnosiliconAuthenticationResult : EmptyResult
    {
        [JsonPropertyName("jwt")]
        public string? jwt { get; set; }
    }
}
