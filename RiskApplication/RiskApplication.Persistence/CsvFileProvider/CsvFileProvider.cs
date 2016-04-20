using System.Collections.Generic;
using System.IO;
using CsvHelper;
using RiskApplication.Persistence.Factory;

namespace RiskApplication.Persistence.CsvFileProvider
{
    public interface ICsvFileProvider<T> where T : class
    {
        IEnumerable<T> ReadCsvFile(string filePath);
    }

    public class CsvFileProvider<T> : ICsvFileProvider<T> where T : class
    {
        private readonly IBetFactory<T> _betFactory;

        public CsvFileProvider(IBetFactory<T> betFactory)
        {
            _betFactory = betFactory;
        }

        public IEnumerable<T> ReadCsvFile(string filePath)
        {
            var newBets = new List<T>();

            using (TextReader textReader = File.OpenText(filePath))
            {
                var csvReader = new CsvReader(textReader);
                while (csvReader.Read())
                {
                    var bet = _betFactory.CreateBet(csvReader);
                    newBets.Add(bet);
                }
            }

            return newBets;
        }
    }
}