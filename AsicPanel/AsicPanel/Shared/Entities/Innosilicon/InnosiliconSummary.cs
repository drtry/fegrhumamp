using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsicPanel.Shared.Entities.Innosilicon
{
    public class InnosiliconSummary
    {
        public InnosiliconSummaryDevice[] DEVS { get; set; }

        public InnosiliconPool[] POOLS { get; set; }

        public InnosiliconHardware HARDWARE { get; set; }

        public bool tuning { get; set; }

        public object[] Hashrates { get; set; }

        public InnosiliconTotalHash TotalHash { get; set; }
    }
}
