using System.Text.Json.Serialization;

namespace BLL.Entities.Innosilicon
{
    public class InnosiliconHardware
    {
        [JsonPropertyName("Fan duty")]
        public int FanDuty { get; set; }
    }
}
