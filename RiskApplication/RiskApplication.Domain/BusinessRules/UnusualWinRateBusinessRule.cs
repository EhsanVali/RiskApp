using RiskApplication.Domain.Models;

namespace RiskApplication.Domain.BusinessRules
{
    public class UnusualWinRateBusinessRule
    {
        public bool IsSatisfied(Customer customer)
        {
            return customer != null && customer.WinningPercentage >= 60;
        }
    }
}