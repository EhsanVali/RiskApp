namespace RiskApplication.Domain.Models
{
    public class UnsettledBetWithStatistics
    {
        public CustomerStatistics CustomerStatistics { get; set; }
        public UnsettledBet UnsettledBet { get; set; }
    }
}