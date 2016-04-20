namespace RiskApplication.Domain.Models
{
    public class CustomerStatistics
    {
        public int Customer { get; set; }
        public double AverageStake { get; set; }
        public int TotalBets { get; set; }
        public int TotalBetsWon { get; set; }

        public double WinningPercentage => TotalBets == 0
            ? 0
            : TotalBetsWon * 100.0 / TotalBets;
    }
}