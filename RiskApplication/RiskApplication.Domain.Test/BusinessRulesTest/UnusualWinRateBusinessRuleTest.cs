using NUnit.Framework;
using RiskApplication.Domain.BusinessRules;
using RiskApplication.Domain.Models;

namespace RiskApplication.Domain.Test.BusinessRulesTest
{
    [TestFixture]
    public class UnusualWinRateBusinessRuleTest
    {
        [SetUp]
        public void Setup()
        {
            _rule = new UnusualWinRateBusinessRule();
        }

        private UnusualWinRateBusinessRule _rule;

        [TestCase(100, 59, false)]
        [TestCase(100, 60, true)]
        [TestCase(100, 61, true)]
        public void ShouldReturnExpectedResult(int totalBets, int totalWins, bool expected)
        {
            var result = _rule.IsValid(new Customer
            {
                TotalBets = totalBets,
                TotalBetsWon = totalWins
            });

            Assert.AreEqual(result, expected);
        }

        [Test]
        public void ShouldReturnFalseWhenNullInput()
        {
            Assert.IsFalse(_rule.IsValid(null));
        }
    }
}