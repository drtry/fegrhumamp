using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AsicPanel.Shared.Entities.Innosilicon
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
