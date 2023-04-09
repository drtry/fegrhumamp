using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BLL.Entities.Innosilicon
{
    public class InnosiliconPool
    {
        [JsonPropertyName("POOL")]
        public int POOL { get; set; }

        [JsonPropertyName("URL")]
        public string URL { get; set; }

        [JsonPropertyName("Status")]
        public string Status { get; set; }

        [JsonPropertyName("Priority")]
        public int Priority { get; set; }

        [JsonPropertyName("Quota")]
        public int Quota { get; set; }

        [JsonPropertyName("Long Poll")]
        public string LongPoll { get; set; }

        [JsonPropertyName("Getworks")]
        public int Getworks { get; set; }

        [JsonPropertyName("Accepted")]
        public int Accepted { get; set; }

        [JsonPropertyName("Rejected")]
        public int Rejected { get; set; }

        [JsonPropertyName("Works")]
        public int Works { get; set; }

        [JsonPropertyName("Discarded")]
        public int Discarded { get; set; }

        [JsonPropertyName("Stale")]
        public int Stale { get; set; }

        [JsonPropertyName("Get Failures")]
        public int GetFailures { get; set; }

        [JsonPropertyName("Remote Failures")]
        public int RemoteFailures { get; set; }

        [JsonPropertyName("User")]
        public string User { get; set; }

        [JsonPropertyName("Last Share Time")]
        public long LastShareTime { get; set; }

        [JsonPropertyName("Diff1 Shares")]
        public int Diff1Shares { get; set; }

        [JsonPropertyName("Proxy Type")]
        public string ProxyType { get; set; }

        [JsonPropertyName("Proxy")]
        public string Proxy { get; set; }

        [JsonPropertyName("Difficulty Accepted")]
        public int DifficultyAccepted { get; set; }

        [JsonPropertyName("Difficulty Rejected")]
        public int DifficultyRejected { get; set; }

        [JsonPropertyName("Difficulty Stale")]
        public int DifficultyStale { get; set; }

        [JsonPropertyName("Last Share Difficulty")]
        public int LastShareDifficulty { get; set; }

        [JsonPropertyName("Work Difficulty")]
        public int WorkDifficulty { get; set; }

        [JsonPropertyName("Has Stratum")]
        public bool HasStratum { get; set; }

        [JsonPropertyName("Stratum Active")]
        public bool StratumActive { get; set; }

        [JsonPropertyName("Stratum URL")]
        public string StratumURL { get; set; }

        [JsonPropertyName("Stratum Difficulty")]
        public int StratumDifficulty { get; set; }

        [JsonPropertyName("Has Vmask")]
        public bool HasVmask { get; set; }

        [JsonPropertyName("Has GBT")]
        public bool HasGBT { get; set; }

        [JsonPropertyName("Best Share")]
        public int BestShare { get; set; }

        [JsonPropertyName("Pool Rejected%")]
        public int PoolRejectedPercent { get; set; }

        [JsonPropertyName("Pool Stale%")]
        public int PoolStalePercent { get; set; }

        [JsonPropertyName("Bad Work")]
        public int BadWork { get; set; }

        [JsonPropertyName("Current Block Height")]
        public long CurrentBlockHeight { get; set; }

        [JsonPropertyName("Current Block Version")]
        public long CurrentBlockVersion { get; set; }
    }
}
