using System.Text.Json.Serialization;

namespace BLL.Entities.Innosilicon
{
    public class InnosiliconSummaryDevice
    {
        [JsonPropertyName("ASC")]
        public int ASC { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("ID")]
        public int ID { get; set; }

        [JsonPropertyName("Enabled")]
        public string Enabled { get; set; }

        [JsonPropertyName("Status")]
        public string Status { get; set; }

        [JsonPropertyName("Temperature")]
        public int Temperature { get; set; }

        [JsonPropertyName("MHS av")]
        public double MHSav { get; set; }

        [JsonPropertyName("MHS 5s")]
        public double MHS5s { get; set; }

        [JsonPropertyName("MHS 1m")]
        public double MHS1m { get; set; }

        [JsonPropertyName("MHS 5m")]
        public double MHS5m { get; set; }

        [JsonPropertyName("MHS 15m")]
        public double MHS15m { get; set; }

        [JsonPropertyName("Accepted")]
        public int Accepted { get; set; }

        [JsonPropertyName("Rejected")]
        public int Rejected { get; set; }

        [JsonPropertyName("Hardware Errors")]
        public int HardwareErrors { get; set; }

        [JsonPropertyName("Utility")]
        public double Utility { get; set; }

        [JsonPropertyName("Last Share Pool")]
        public int LastSharePool { get; set; }

        [JsonPropertyName("Last Share Time")]
        public int LastShareTime { get; set; }

        [JsonPropertyName("Total MH")]
        public int TotalMH { get; set; }

        [JsonPropertyName("Diff1 Work")]
        public int Diff1Work { get; set; }

        [JsonPropertyName("Difficulty Accepted")]
        public int DifficultyAccepted { get; set; }

        [JsonPropertyName("Difficulty Rejected")]
        public int DifficultyRejected { get; set; }

        [JsonPropertyName("Last Share Difficulty")]
        public int LastShareDifficulty { get; set; }

        [JsonPropertyName("Last Valid Work")]
        public int LastValidWork { get; set; }

        [JsonPropertyName("Device Hardware%")]
        public double DeviceHardwarePercent { get; set; }

        [JsonPropertyName("Device Rejected%")]
        public double DeviceRejectedPercent { get; set; }

        [JsonPropertyName("Device Elapsed")]
        public int DeviceElapsed { get; set; }

        [JsonPropertyName("Sync Power")]
        public bool SyncPower { get; set; }

        [JsonPropertyName("Vendor")]
        public string Vendor { get; set; }

        [JsonPropertyName("Power Vendor")]
        public string PowerVendor { get; set; }

        [JsonPropertyName("Power Version")]
        public string PowerVersion { get; set; }

        [JsonPropertyName("Tune hash")]
        public int TuneHash { get; set; }

        [JsonPropertyName("Chain ID")]
        public int ChainID { get; set; }

        [JsonPropertyName("vidOptimal")]
        public bool VidOptimal { get; set; }

        [JsonPropertyName("chkVoltFlag")]
        public bool ChkVoltFlag { get; set; }

        [JsonPropertyName("bistTuneDone")]
        public bool BistTuneDone { get; set; }

        [JsonPropertyName("voltBalDone")]
        public bool VoltBalDone { get; set; }

        [JsonPropertyName("pllRefineDone")]
        public bool PllRefineDone { get; set; }

        [JsonPropertyName("Hash Rate")]
        public double HashRate { get; set; }

        [JsonPropertyName("Unit")]
        public string Unit { get; set; }

        [JsonPropertyName("Hash Rate H")]
        public double HashRateH { get; set; }
    }
}
