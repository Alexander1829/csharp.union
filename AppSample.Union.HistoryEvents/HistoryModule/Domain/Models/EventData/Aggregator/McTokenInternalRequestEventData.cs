using System.Text.Json.Serialization;

namespace AppSample.Union.HistoryEvents.HistoryModule.Domain.Models.EventData.Aggregator;

public record struct McTokenInternalRequestEventData : IHistoryEventData
{
    [JsonIgnore]
    public HistoryEventType EventType => HistoryEventType.McTokenInternalRequest;
}
