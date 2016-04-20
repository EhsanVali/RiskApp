using RiskApplication.Domain.Models;

namespace RiskApplication.Domain.BusinessRules
{
    public interface IUnusualStakeBusinessRule : IBusinessRule<CustomerUnsettledBet>
    {
    }

    public class UnusualStakeBusinessRule : IUnusualStakeBusinessRule
    {
        public bool IsValid(CustomerUnsettledBet customerUnsettledBet)
        {
            if (customerUnsettledBet?.UnsettledBet == null || customerUnsettledBet.Customer == null)
            {
                return false;
            }

            return customerUnsettledBet.Customer.AverageStake * 10 <= customerUnsettledBet.UnsettledBet.Stake;
        }
    }
}