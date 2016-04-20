using RiskApplication.Domain.Models;

namespace RiskApplication.Domain.BusinessRules
{
    public interface IHighPriceBusinessRule : IBusinessRule<UnsettledBet>
    {
    }

    public class HighPriceBusinessRule : IHighPriceBusinessRule
    {
        public bool IsValid(UnsettledBet unsettledBet)
        {
            return unsettledBet != null && unsettledBet.ToWin >= 1000;
        }
    }
}