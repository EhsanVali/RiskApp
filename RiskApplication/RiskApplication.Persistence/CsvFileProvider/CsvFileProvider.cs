using System.Collections.Generic;

namespace RiskApplication.Persistence.CsvFileProvider
{
    public interface ICsvFileProvider<T> where T : class
    {
        IEnumerable<T> ReadCsvFile(string filePath);
    }

    public class CsvFileProvider<T> : ICsvFileProvider<T> where T : class
    {
        public IEnumerable<T> ReadCsvFile(string filePath)
        {
            throw new System.NotImplementedException();
        }
    }
}