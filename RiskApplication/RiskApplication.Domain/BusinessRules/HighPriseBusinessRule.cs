using RiskApplication.Domain.Models;

namespace RiskApplication.Domain.BusinessRules
{
    public interface IHighPriseBusinessRule : IBusinessRule<UnsettledBet>
    {
    }

    public class HighPriseBusinessRule : IHighPriseBusinessRule
    {
        public bool IsValid(UnsettledBet unsettledBet)
        {
            return unsettledBet != null && unsettledBet.ToWin >= 1000;
        }
    }
}