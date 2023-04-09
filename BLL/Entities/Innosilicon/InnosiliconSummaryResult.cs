using System.Text.Json.Serialization;

namespace BLL.Entities.Innosilicon
{
    public class InnosiliconSummaryResult : EmptyResult
    {
        [JsonPropertyName("DEVS")]
        public InnosiliconSummaryDevice[] DEVS { get; set; }

        [JsonPropertyName("POOLS")]
        public InnosiliconPool[] POOLS { get; set; }

        [JsonPropertyName("HARDWARE")]
        public InnosiliconHardware HARDWARE { get; set; }

        [JsonPropertyName("tuning")]
        public bool tuning { get; set; }

        [JsonPropertyName("Hashrates")]
        public object[] Hashrates { get; set; }

        [JsonPropertyName("TotalHash")]
        public InnosiliconTotalHash TotalHash { get; set; }
    }
}
