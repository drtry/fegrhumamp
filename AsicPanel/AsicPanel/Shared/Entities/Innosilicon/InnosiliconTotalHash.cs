using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AsicPanel.Shared.Entities.Innosilicon
{
    public class InnosiliconTotalHash
    {
        [JsonPropertyName("Hash Rate")]
        public double HashRate { get; set; }

        [JsonPropertyName("Unit")]
        public string Unit { get; set; }
    }
}
