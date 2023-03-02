namespace AppSample.Union.HistoryEvents.HistoryModule.Domain;

public class HistoryServiceSettings
{
    public string Host { get; init; }
    public string UserName { get; init; }
    public string UserPass { get; init; }
    public int EventsBatchSize { get; init; }
}