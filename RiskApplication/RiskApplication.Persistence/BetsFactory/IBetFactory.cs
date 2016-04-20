using CsvHelper;

namespace RiskApplication.Persistence.BetsFactory
{
    public interface IBetFactory<T> where T : class
    {
        T CreateBet(ICsvReader csvReader);
    }
}