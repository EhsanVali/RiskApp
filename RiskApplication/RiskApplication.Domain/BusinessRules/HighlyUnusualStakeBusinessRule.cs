using RiskApplication.Domain.Models;

namespace RiskApplication.Domain.BusinessRules
{
    public interface IHighlyUnusualStakeBusinessRule : IBusinessRule<CustomerUnsettledBet>
    {
    }

    public class HighlyUnusualStakeBusinessRule : IHighlyUnusualStakeBusinessRule
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