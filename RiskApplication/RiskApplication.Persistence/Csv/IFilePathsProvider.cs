namespace RiskApplication.Persistence.Csv
{
    public interface IFilePathsProvider
    {
        string GetSettledBetsFilePath();
        string GetUnsettledBetsFilePath();
    }
}