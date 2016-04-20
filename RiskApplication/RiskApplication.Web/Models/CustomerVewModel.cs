namespace RiskApplication.Web.Models
{
    public class CustomerVewModel
    {
        public int Id { get; set; }
        public double AverageStake { get; set; }
        public int TotalBets { get; set; }
        public int TotalBetsWon { get; set; }
        public double WinningPercentage { get; set; }
    }
}