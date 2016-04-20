using NUnit.Framework;
using RiskApplication.Domain.BusinessRules;
using RiskApplication.Domain.Models;

namespace RiskApplication.Domain.Test.BusinessRulesTest
{
    [TestFixture]
    public class HighlyUnusualStakeBusinessRuleTest
    {
        [SetUp]
        public void Setup()
        {
            _rule = new HighlyUnusualStakeBusinessRule();
        }

        private HighlyUnusualStakeBusinessRule _rule;

        [TestCase(10, 299, false)]
        [TestCase(10, 300, true)]
        [TestCase(10, 301, true)]
        public void ShouldReturnExpectedResult(int averageStake, int currentStake, bool expected)
        {
            var bet = new UnsettledBet
            {
                Stake = currentStake
            };

            var customer = new Customer
            {
                AverageStake = averageStake
            };

            var result = _rule.IsValid(new CustomerUnsettledBet
            {
                Customer = customer,
                UnsettledBet = bet
            });

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ShouldReturnFalseWhenNullInput()
        {
            var result = _rule.IsValid(null);
            Assert.IsFalse(result);
        }

        [Test]
        public void ShouldReturnFalseWhenNullStatistics()
        {
            var result = _rule.IsValid(new CustomerUnsettledBet
            {
                Customer = null,
                UnsettledBet = new UnsettledBet()
            });

            Assert.IsFalse(result);
        }

        [Test]
        public void ShouldReturnFalseWhenNullUnsettledBet()
        {
            var result = _rule.IsValid(new CustomerUnsettledBet
            {
                Customer = new Customer(),
                UnsettledBet = null
            });

            Assert.IsFalse(result);
        }
    }
}