using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsicPanel.Shared.Entities
{
    public class Settings
    {
        public Device[] Devices { get; set; }
    }
    public class Device
    {
        public string Ip { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
    }
}
