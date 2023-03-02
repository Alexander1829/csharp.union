using System.Text.Json.Serialization;

namespace AppSample.Union.HistoryEvents.HistoryModule.Domain.Models.EventData.Aggregator;

public record struct McTokenRequestEventData : IHistoryEventData
{
    [JsonIgnore]
    public HistoryEventType EventType => HistoryEventType.McTokenRequest;
}
