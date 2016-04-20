using CsvHelper;

namespace RiskApplication.Persistence.Factory
{
    public interface IBetFactory<T> where T : class
    {
        T CreateBet(ICsvReader csvReader);
    }
}