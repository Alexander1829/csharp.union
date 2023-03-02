using System.Text.Json.Serialization;

namespace AppSample.Union.HistoryEvents.HistoryModule.Domain.Models.EventData.Aggregator;

public record struct DiMsisdnRegisteredEventData([property: JsonPropertyName("m")] string Msisdn) : IHistoryEventData
{
    [JsonIgnore]
    public HistoryEventType EventType => HistoryEventType.DiMsisdnRegistered;
}