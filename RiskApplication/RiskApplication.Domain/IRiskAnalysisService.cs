using System.Collections.Generic;
using RiskApplication.Domain.Models;

namespace RiskApplication.Domain
{
    public interface IRiskAnalysisService
    {
        IEnumerable<SettledBet> ReadAllSettledBets(int customer);
        IEnumerable<UnsettledBet> ReadAllUnsettledBets();
        IEnumerable<Customer> GetCustomers();
        IEnumerable<UnsettledBetRiskAnalysis> GetUnsettledBetsRiskAnalysis();
    }
}