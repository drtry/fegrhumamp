using System.Text.Json.Serialization;

namespace BLL.Entities.Innosilicon.Response
{
    public class InnosiliconHardware
    {
        [JsonPropertyName("Fan duty")]
        public int FanDuty { get; set; }
    }
}
