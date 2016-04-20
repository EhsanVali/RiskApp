using System.Collections.Generic;
using System.Linq;
using RiskApplication.Domain;
using RiskApplication.Domain.BusinessRules;
using RiskApplication.Domain.Models;

namespace RiskApplication.Services
{
    public class RiskAnalysisService : IRiskAnalysisService
    {
        private readonly IHighlyUnusualStakeBusinessRule _highlyUnusualStakeBusinessRule;
        private readonly IHighPriceBusinessRule _highPriceBusinessRule;
        private readonly IRiskRepository _riskRepository;
        private readonly IUnusualStakeBusinessRule _unusualStakeBusinessRule;
        private readonly IUnusualWinRateBusinessRule _unusualWinRateBusinessRule;

        public RiskAnalysisService(IRiskRepository riskRepository,
                                   IHighPriceBusinessRule highPriceBusinessRule,
                                   IUnusualStakeBusinessRule unusualStakeBusinessRule,
                                   IHighlyUnusualStakeBusinessRule highlyUnusualStakeBusinessRule,
                                   IUnusualWinRateBusinessRule unusualWinRateBusinessRule)
        {
            _riskRepository = riskRepository;
            _highPriceBusinessRule = highPriceBusinessRule;
            _unusualStakeBusinessRule = unusualStakeBusinessRule;
            _highlyUnusualStakeBusinessRule = highlyUnusualStakeBusinessRule;
            _unusualWinRateBusinessRule = unusualWinRateBusinessRule;
        }

        public IEnumerable<SettledBet> ReadAllSettledBets(int customerId)
        {
            return _riskRepository.GetAllSettledBets()
                                  .Where(settledBet => settledBet.CustomerId == customerId);
        }

        public IEnumerable<UnsettledBet> ReadAllUnsettledBets()
        {
            return _riskRepository.GetAllUnsettledBets();
        }

        public IEnumerable<Customer> GetCustomers()
        {
            var settledBets = _riskRepository.GetAllSettledBets();
            return settledBets
                .GroupBy(settledBet => settledBet.CustomerId)
                .Select(bets => new Customer
                {
                    Id = bets.Key,
                    AverageStake = bets.Average(q => q.Stake),
                    TotalBets = bets.Count(),
                    TotalBetsWon = bets.Count(q => q.Win > 0)
                });
        }

        public IEnumerable<UnsettledBetRiskAnalysis> GetUnsettledBetsRiskAnalysis()
        {
            var customerUnsettledBets = GetCustomerUnsettledBet();
            return customerUnsettledBets.Select(unsettledBetWithStatistics => new UnsettledBetRiskAnalysis
            {
                WinningPercentage = unsettledBetWithStatistics.Customer?.WinningPercentage ?? 0,
                UnsettledBet = unsettledBetWithStatistics.UnsettledBet,
                RiskAnalysis = new RiskAnalysis
                {
                    IsHighPrize = _highPriceBusinessRule.IsValid(unsettledBetWithStatistics.UnsettledBet),
                    IsUnusuallyHighStake = _highlyUnusualStakeBusinessRule.IsValid(unsettledBetWithStatistics),
                    HasUnusualWinRate = _unusualWinRateBusinessRule.IsValid(unsettledBetWithStatistics.Customer),
                    IsHighStake = _unusualStakeBusinessRule.IsValid(unsettledBetWithStatistics)
                }
            });
        }

        private IEnumerable<CustomerUnsettledBet> GetCustomerUnsettledBet()
        {
            var statistics = GetCustomers();
            var unsettledBets = ReadAllUnsettledBets();

            var query = from bet in unsettledBets
                        join customerStatistics in statistics on bet.CustomerId equals customerStatistics.Id into
                            customerStatisticses
                        from customerStatistics in customerStatisticses.DefaultIfEmpty()
                        select new CustomerUnsettledBet
                        {
                            Customer = customerStatistics,
                            UnsettledBet = bet
                        };

            return query.ToList();
        }
    }
}