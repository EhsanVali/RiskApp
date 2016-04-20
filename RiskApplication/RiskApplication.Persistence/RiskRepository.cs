using System.Collections.Generic;
using RiskApplication.Domain;
using RiskApplication.Domain.Models;

namespace RiskApplication.Persistence
{
    public class RiskRepository : IRiskRepository
    {
        public IEnumerable<SettledBet> GetAllSettledBets()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<UnsettledBet> GetAllUnsettledBets()
        {
            throw new System.NotImplementedException();
        }
    }
}