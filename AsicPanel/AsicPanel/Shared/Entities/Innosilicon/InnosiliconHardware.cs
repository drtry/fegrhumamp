using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AsicPanel.Shared.Entities.Innosilicon
{
    public class InnosiliconHardware
    {
        [JsonPropertyName("Fan duty")]
        public int FanDuty { get; set; }
    }
}
