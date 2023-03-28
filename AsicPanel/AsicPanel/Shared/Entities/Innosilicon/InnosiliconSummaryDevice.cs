using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsicPanel.Shared.Entities.Innosilicon
{
    public class InnosiliconSummaryDevice
    {
        public int ASC { get; set; }
        public string Name { get; set; }
        public int ID { get; set; }
        public string Enabled { get; set; }
        public string Status { get; set; }
        public int Temperature { get; set; }
        public double MHSav { get; set; }
        public double MHS5s { get; set; }
        public double MHS1m { get; set; }
        public double MHS5m { get; set; }
        public double MHS15m { get; set; }
        public int Accepted { get; set; }
        public int Rejected { get; set; }
        public int HardwareErrors { get; set; }
        public double Utility { get; set; }
        public int LastSharePool { get; set; }
        public int LastShareTime { get; set; }
        public int TotalMH { get; set; }
        public int Diff1Work { get; set; }
        public int DifficultyAccepted { get; set; }
        public int DifficultyRejected { get; set; }
        public int LastShareDifficulty { get; set; }
        public int LastValidWork { get; set; }
        public double DeviceHardwarePercent { get; set; }
        public double DeviceRejectedPercent { get; set; }
        public int DeviceElapsed { get; set; }
        public bool SyncPower { get; set; }
        public string Vendor { get; set; }
        public string PowerVendor { get; set; }
        public string PowerVersion { get; set; }
        public int TuneHash { get; set; }
        public int ChainID { get; set; }
        public bool VidOptimal { get; set; }
        public bool ChkVoltFlag { get; set; }
        public bool BistTuneDone { get; set; }
        public bool VoltBalDone { get; set; }
        public bool PllRefineDone { get; set; }
        public double HashRate { get; set; }
        public string Unit { get; set; }
        public double HashRateH { get; set; }
    }
}
