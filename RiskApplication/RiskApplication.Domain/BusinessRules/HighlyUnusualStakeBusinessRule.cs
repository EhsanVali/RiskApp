using RiskApplication.Domain.Models;

namespace RiskApplication.Domain.BusinessRules
{
    public class HighlyUnusualStakeBusinessRule
    {
        public bool IsValid(CustomerUnsettledBet customerUnsettledBet)
        {
            if (customerUnsettledBet?.UnsettledBet == null || customerUnsettledBet.Customer == null)
            {
                return false;
            }

            return customerUnsettledBet.Customer.AverageStake * 30 <= customerUnsettledBet.UnsettledBet.Stake;
        }
    }
}