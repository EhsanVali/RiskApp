using RiskApplication.Domain.Models;

namespace RiskApplication.Domain.BusinessRules
{
    public class UnusualStakeBusinessRule
    {
        public bool IsSatisfied(CustomerUnsettledBet customerUnsettledBet)
        {
            if (customerUnsettledBet?.UnsettledBet == null || customerUnsettledBet.Customer == null)
            {
                return false;
            }

            return customerUnsettledBet.Customer.AverageStake * 10 <= customerUnsettledBet.UnsettledBet.Stake;
        }
    }
}