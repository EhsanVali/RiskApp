using System.Collections.Generic;
using RiskApplication.Domain;
using RiskApplication.Domain.Models;
using RiskApplication.Persistence.CsvFileProvider;

namespace RiskApplication.Persistence
{
    public class RiskRepository : IRiskRepository
    {
        private readonly IFilePathsProvider _filePathsProvider;
        private readonly ICsvFileProvider<SettledBet> _settledBetCsvFileProvider;
        private readonly ICsvFileProvider<UnsettledBet> _unsettledBetCsvFileProvider;

        public RiskRepository(IFilePathsProvider filePathsProvider,
                              ICsvFileProvider<SettledBet> settledBetCsvFileProvider,
                              ICsvFileProvider<UnsettledBet> unsettledBetCsvFileProvider)
        {
            _filePathsProvider = filePathsProvider;
            _settledBetCsvFileProvider = settledBetCsvFileProvider;
            _unsettledBetCsvFileProvider = unsettledBetCsvFileProvider;
        }

        public IEnumerable<SettledBet> GetAllSettledBets()
        {
            var path = _filePathsProvider.GetSettledBetsFilePath();
            return _settledBetCsvFileProvider.ReadCsvFile(path);
        }

        public IEnumerable<UnsettledBet> GetAllUnsettledBets()
        {
            var path = _filePathsProvider.GetUnsettledBetsFilePath();
            return _unsettledBetCsvFileProvider.ReadCsvFile(path);
        }
    }
}