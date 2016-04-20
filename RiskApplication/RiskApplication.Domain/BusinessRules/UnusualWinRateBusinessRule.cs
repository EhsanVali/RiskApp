using RiskApplication.Domain.Models;

namespace RiskApplication.Domain.BusinessRules
{
    public interface IUnusualWinRateBusinessRule : IBusinessRule<Customer>
    {
    }

    public class UnusualWinRateBusinessRule : IUnusualWinRateBusinessRule
    {
        public bool IsValid(Customer customer)
        {
            return customer != null && customer.WinningPercentage >= 60;
        }
    }
}