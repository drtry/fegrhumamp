﻿namespace BLL.Entities
{
    public class Settings
    {
        public List<Device> Devices { get; set; }
    }
    public class Device
    {
        public string Ip { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }

        //public bool Status { get; set; }
    }
}
