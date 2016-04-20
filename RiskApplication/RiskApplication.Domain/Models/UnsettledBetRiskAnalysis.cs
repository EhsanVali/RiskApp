namespace RiskApplication.Domain.Models
{
    public class UnsettledBetRiskAnalysis
    {
        public double WinningPercentage { get; set; }
        public RiskAnalysis RiskAnalysis { get; set; }
        public UnsettledBet UnsettledBet { get; set; }
    }
}