using RiskApplication.Domain.Models;

namespace RiskApplication.Domain.BusinessRules
{
    public class HighPriseBusinessRule
    {
        public bool IsValid(UnsettledBet unsettledBet)
        {
            return unsettledBet != null && unsettledBet.ToWin >= 1000;
        }
    }
}