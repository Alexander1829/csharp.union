using System.Text.Json.Serialization;

namespace AppSample.Union.HistoryEvents.HistoryModule.Domain.Models.EventData.Aggregator;

public record struct SiSpPollingRequestEventData : IHistoryEventData
{
    [JsonIgnore]
    public HistoryEventType EventType => HistoryEventType.SiSpPollingRequest;
}