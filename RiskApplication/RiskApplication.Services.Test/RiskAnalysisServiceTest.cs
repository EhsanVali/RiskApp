using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using RiskApplication.Domain;
using RiskApplication.Domain.BusinessRules;
using RiskApplication.Domain.Models;

namespace RiskApplication.Services.Test
{
    [TestFixture]
    public class RiskAnalysisServiceTest
    {
        [SetUp]
        public void Setup()
        {
            _repository = new Mock<IRiskRepository>();
            _service = new RiskAnalysisService(_repository.Object,
                new HighPriceBusinessRule(),
                new UnusualStakeBusinessRule(),
                new HighlyUnusualStakeBusinessRule(),
                new UnusualWinRateBusinessRule());
        }

        private Mock<IRiskRepository> _repository;
        private RiskAnalysisService _service;

        [Test]
        public void ShouldReturnClientStatisticsAsExpected()
        {
            _repository.Setup(p => p.GetAllSettledBets()).Returns(new List<SettledBet>
            {
                new SettledBet {CustomerId = 1, Stake = 20, Win = 50},
                new SettledBet {CustomerId = 1, Stake = 40, Win = 0},
                new SettledBet {CustomerId = 1, Stake = 35, Win = 0},
                new SettledBet {CustomerId = 1, Stake = 25, Win = 40},
                new SettledBet {CustomerId = 2, Stake = 100, Win = 125},
                new SettledBet {CustomerId = 2, Stake = 50, Win = 90}
            });

            var result = _service.GetCustomers().ToList();
            Assert.AreEqual(2, result.Count());

            var first = result.First(c => c.Id == 1);
            Assert.AreEqual(30, first.AverageStake);
            Assert.AreEqual(4, first.TotalBets);
            Assert.AreEqual(2, first.TotalBetsWon);
            Assert.AreEqual(50, first.WinningPercentage);

            var second = result.First(c => c.Id == 2);
            Assert.AreEqual(75, second.AverageStake);
            Assert.AreEqual(2, second.TotalBets);
            Assert.AreEqual(2, second.TotalBetsWon);
            Assert.AreEqual(100, second.WinningPercentage);
        }

        [Test]
        public void ShouldReturnCorrectRiskAnalysis()
        {
            _repository.Setup(p => p.GetAllSettledBets()).Returns(new List<SettledBet>
            {
                new SettledBet {CustomerId = 1, Stake = 20, Win = 35},
                new SettledBet {CustomerId = 1, Stake = 40, Win = 0},
                new SettledBet {CustomerId = 2, Stake = 100, Win = 125},
                new SettledBet {CustomerId = 2, Stake = 50, Win = 90}
            });

            _repository.Setup(p => p.GetAllUnsettledBets()).Returns(new List<UnsettledBet>
            {
                new UnsettledBet {CustomerId = 1, Stake = 301, ToWin = 1500}, //high price, unusual stake
                new UnsettledBet {CustomerId = 1, Stake = 1000, ToWin = 1500},//high price, unusual stake, unusually high stake

                new UnsettledBet {CustomerId = 2, Stake = 25, ToWin = 50}, //high winning rate -> 100%
                new UnsettledBet {CustomerId = 3, Stake = 40, ToWin = 60} //new customer, no history yet, no other risks
            });

            var list = _service.GetUnsettledBetsRiskAnalysis().ToList();
            Assert.AreEqual(4, list.Count);

            var c1 = list.First(p => p.UnsettledBet.Stake == 301);
            Assert.IsTrue(c1.RiskAnalysis.IsHighPrice);
            Assert.IsTrue(c1.RiskAnalysis.IsHighStake);
            Assert.IsFalse(c1.RiskAnalysis.IsUnusuallyHighStake);
            Assert.IsFalse(c1.RiskAnalysis.HasUnusualWinRate);
            Assert.AreEqual(c1.WinningPercentage, 50);

            var c2 = list.First(p => p.UnsettledBet.Stake == 1000);
            Assert.IsTrue(c2.RiskAnalysis.IsHighPrice);
            Assert.IsTrue(c2.RiskAnalysis.IsHighStake);
            Assert.IsTrue(c2.RiskAnalysis.IsUnusuallyHighStake);
            Assert.IsFalse(c2.RiskAnalysis.HasUnusualWinRate);
            Assert.AreEqual(c2.WinningPercentage, 50);

            var c3 = list.First(p => p.UnsettledBet.Stake == 25);
            Assert.IsFalse(c3.RiskAnalysis.IsHighPrice);
            Assert.IsFalse(c3.RiskAnalysis.IsHighStake);
            Assert.IsFalse(c3.RiskAnalysis.IsUnusuallyHighStake);
            Assert.IsTrue(c3.RiskAnalysis.HasUnusualWinRate);
            Assert.AreEqual(c3.WinningPercentage, 100);

            var c4 = list.First(p => p.UnsettledBet.Stake == 40);
            Assert.IsFalse(c4.RiskAnalysis.IsHighPrice);
            Assert.IsFalse(c4.RiskAnalysis.IsHighStake);
            Assert.IsFalse(c4.RiskAnalysis.IsUnusuallyHighStake);
            Assert.IsFalse(c4.RiskAnalysis.HasUnusualWinRate);
            Assert.AreEqual(c4.WinningPercentage, 0);
        }

        [Test]
        public void ShouldReturnSettledBetsForASpecificCustomer()
        {
            _repository.Setup(p => p.GetAllSettledBets()).Returns(new List<SettledBet>
            {
                new SettledBet {CustomerId = 1, Stake = 20, Win = 50},
                new SettledBet {CustomerId = 1, Stake = 40, Win = 0},
                new SettledBet {CustomerId = 1, Stake = 35, Win = 0},
                new SettledBet {CustomerId = 1, Stake = 25, Win = 40},
                new SettledBet {CustomerId = 2, Stake = 100, Win = 125},
                new SettledBet {CustomerId = 2, Stake = 50, Win = 90}
            });

            var result = _service.ReadAllSettledBets(1).ToList();
            Assert.AreEqual(4, result.Count());
            Assert.AreEqual(1, result[0].CustomerId);
        }
    }
}