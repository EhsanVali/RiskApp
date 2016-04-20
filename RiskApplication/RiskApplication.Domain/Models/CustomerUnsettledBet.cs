namespace RiskApplication.Domain.Models
{
    public class CustomerUnsettledBet
    {
        public Customer Customer { get; set; }
        public UnsettledBet UnsettledBet { get; set; }
    }
}