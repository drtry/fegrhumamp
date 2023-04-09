using System.Text.Json.Serialization;

namespace BLL.Entities
{
    public class EmptyResult
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
