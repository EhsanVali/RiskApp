using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using RiskApplication.Domain.Models;
using RiskApplication.Persistence.CsvFileProvider;

namespace RiskApplication.Persistence.Test
{
    [TestFixture]
    public class RiskRepositoryTest
    {
        [SetUp]
        public void Setup()
        {
            _settledBetCsvFileReader = new Mock<ICsvFileProvider<SettledBet>>();
            _unsettledBetCsvFileReader = new Mock<ICsvFileProvider<UnsettledBet>>();
            _filePathsProvider = new Mock<IFilePathsProvider>();

            _filePathsProvider.Setup(p => p.GetSettledBetsFilePath()).Returns(SettledBetsFilePath);
            _filePathsProvider.Setup(p => p.GetUnsettledBetsFilePath()).Returns(UnsettledBetsFilePath);

            _repository = new RiskRepository(_filePathsProvider.Object,
                _settledBetCsvFileReader.Object,
                _unsettledBetCsvFileReader.Object);
        }

        private const string SettledBetsFilePath = "X:\\settled.csv";
        private const string UnsettledBetsFilePath = "X:\\unsettled.csv";
        private Mock<ICsvFileProvider<SettledBet>> _settledBetCsvFileReader;
        private Mock<ICsvFileProvider<UnsettledBet>> _unsettledBetCsvFileReader;
        private Mock<IFilePathsProvider> _filePathsProvider;
        private RiskRepository _repository;

        [Test]
        public void ShouldReadSettledBets()
        {
            _settledBetCsvFileReader.Setup(p => p.ReadCsvFile(SettledBetsFilePath)).Returns(new List<SettledBet>
            {
                new SettledBet {CustomerId = 1, Stake = 20, Win = 50},
                new SettledBet {CustomerId = 2, Stake = 50, Win = 90}
            });

            var list = _repository.GetAllSettledBets();
            Assert.AreEqual(2, list.Count());
        }

        [Test]
        public void ShouldReadUnsettledBets()
        {
            _unsettledBetCsvFileReader.Setup(p => p.ReadCsvFile(UnsettledBetsFilePath)).Returns(new List<UnsettledBet>
            {
                new UnsettledBet {CustomerId = 1, Stake = 301, ToWin = 1500},
                new UnsettledBet {CustomerId = 2, Stake = 25, ToWin = 50},
                new UnsettledBet {CustomerId = 3, Stake = 40, ToWin = 60}
            });

            var list = _repository.GetAllUnsettledBets();
            Assert.AreEqual(3, list.Count());
        }
    }
}