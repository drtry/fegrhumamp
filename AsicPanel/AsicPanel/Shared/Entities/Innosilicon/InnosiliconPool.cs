namespace AsicPanel.Shared.Entities.Innosilicon
{
    public class InnosiliconPool
    {
        public int POOL { get; set; }
        public string URL { get; set; }
        public string Status { get; set; }
        public int Priority { get; set; }
        public int Quota { get; set; }
        public string LongPoll { get; set; }
        public int Getworks { get; set; }
        public int Accepted { get; set; }
        public int Rejected { get; set; }
        public int Works { get; set; }
        public int Discarded { get; set; }
        public int Stale { get; set; }
        public int GetFailures { get; set; }
        public int RemoteFailures { get; set; }
        public string User { get; set; }
        public int LastShareTime { get; set; }
        public int Diff1Shares { get; set; }
        public string ProxyType { get; set; }
        public string Proxy { get; set; }
        public int DifficultyAccepted { get; set; }
        public int DifficultyRejected { get; set; }
        public int DifficultyStale { get; set; }
        public int LastShareDifficulty { get; set; }
        public int WorkDifficulty { get; set; }
        public bool HasStratum { get; set; }
        public bool StratumActive { get; set; }
        public string StratumURL { get; set; }
        public int StratumDifficulty { get; set; }
        public bool HasVmask { get; set; }
        public bool HasGBT { get; set; }
        public int BestShare { get; set; }
        public int PoolRejectedPercent { get; set; }
        public int PoolStalePercent { get; set; }
        public int BadWork { get; set; }
        public int CurrentBlockHeight { get; set; }
        public int CurrentBlockVersion { get; set; }
    }
}
