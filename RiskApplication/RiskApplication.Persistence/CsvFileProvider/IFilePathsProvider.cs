namespace RiskApplication.Persistence.CsvFileProvider
{
    public interface IFilePathsProvider
    {
        string GetSettledBetsFilePath();
        string GetUnsettledBetsFilePath();
    }
}