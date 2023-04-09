namespace BLL.Entities.Innosilicon
{
    public class InnosiliconOverview
    {
        public string type { get; set; }
        public Hardware hardware { get; set; }
        public Network network { get; set; }
        public Version version { get; set; }
    }


    public class Hardware
    {
        public string status { get; set; }
        public int memUsed { get; set; }
        public int memFree { get; set; }
        public int memTotal { get; set; }
        public int cacheUsed { get; set; }
        public int cacheFree { get; set; }
        public int cacheTotal { get; set; }
    }

    public class Network
    {
        public string dhcp { get; set; }
        public string ipaddress { get; set; }
        public string netmask { get; set; }
        public string gateway { get; set; }
        public string dns1 { get; set; }
        public string dns2 { get; set; }
    }

    public class Version
    {
        public string hwver { get; set; }
        public string ethaddr { get; set; }
        public string build_date { get; set; }
        public string platform_v { get; set; }
    }
}
