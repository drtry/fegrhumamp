using System.Text.Json.Serialization;

namespace BLL.Entities.Innosilicon
{
    public class InnosiliconTotalHash
    {
        [JsonPropertyName("Hash Rate")]
        public double HashRate { get; set; }

        [JsonPropertyName("Unit")]
        public string Unit { get; set; }
    }
}
