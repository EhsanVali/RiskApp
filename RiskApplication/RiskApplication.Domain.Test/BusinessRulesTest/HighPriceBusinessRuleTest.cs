using NUnit.Framework;
using RiskApplication.Domain.BusinessRules;
using RiskApplication.Domain.Models;

namespace RiskApplication.Domain.Test.BusinessRulesTest
{
    [TestFixture]
    public class HighPriceBusinessRuleTest
    {
        [SetUp]
        public void Setup()
        {
            _rule = new HighPriceBusinessRule();
        }

        private HighPriceBusinessRule _rule;

        [TestCase(999, false)]
        [TestCase(1000, true)]
        [TestCase(1001, true)]
        public void ShouldReturnExpectedResult(int prize, bool expected)
        {
            var bet = new UnsettledBet
            {
                ToWin = prize
            };

            var result = _rule.IsValid(bet);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ShouldReturnFalseWhenNullInput()
        {
            var result = _rule.IsValid(null);
            Assert.IsFalse(result);
        }
    }
}