namespace RiskApplication.Domain.Models
{
    public class RiskAnalysis
    {
        public bool IsHighPrice { get; set; }
        public bool IsUnusuallyHighStake { get; set; }
        public bool IsHighStake { get; set; }
        public bool HasUnusualWinRate { get; set; }
    }
}