using System.Collections.Generic;
using RiskApplication.Domain;
using RiskApplication.Domain.Models;

namespace RiskApplication.Services
{
    public class RiskAnalysisService : IRiskAnalysisService
    {
        private readonly IRiskRepository _riskRepository;

        public RiskAnalysisService(IRiskRepository riskRepository)
        {
            _riskRepository = riskRepository;
        }

        public IEnumerable<SettledBet> ReadAllSettledBets(int customer)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<UnsettledBet> ReadAllUnsettledBets()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Customer> GetCustomers()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<UnsettledBetRiskAnalysis> GetUnsettledBetsRiskAnalysis()
        {
            throw new System.NotImplementedException();
        }
    }
}