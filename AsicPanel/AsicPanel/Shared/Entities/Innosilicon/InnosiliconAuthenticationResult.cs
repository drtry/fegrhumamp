using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsicPanel.Shared.Entities.Innosilicon
{
    public class InnosiliconAuthenticationResult : EmptyResult
    {
        public string? JwtToken { get; set; }
    }
}
