using System.Text.Json.Serialization;

namespace AppSample.Union.HistoryEvents.HistoryModule.Domain.Models.EventData.Aggregator;

public record struct PremiumInfoInternalRequestEventData : IHistoryEventData
{
    [JsonIgnore]
    public HistoryEventType EventType => HistoryEventType.PremiumInfoInternalRequest;
}