using System.Collections.Generic;
using RiskApplication.Domain.Models;

namespace RiskApplication.Domain
{
    public interface IRiskRepository
    {
        IEnumerable<SettledBet> GetAllSettledBets();
        IEnumerable<UnsettledBet> GetAllUnsettledBets();
    }
}