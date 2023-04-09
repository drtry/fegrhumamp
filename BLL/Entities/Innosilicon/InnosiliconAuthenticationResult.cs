using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BLL.Entities.Innosilicon
{
    public class InnosiliconAuthenticationResult : EmptyResult
    {
        [JsonPropertyName("jwt")]
        public string? jwt { get; set; }
    }
}
