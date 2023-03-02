using System.Text.Json.Serialization;

namespace AppSample.Union.HistoryEvents.HistoryModule.Domain.Models.EventData.Aggregator;

public record struct DiIncomingRequestEventData(
    [property: JsonPropertyName("ci")] string ClientId, 
    [property: JsonPropertyName("sc")] string Scope) : IHistoryEventData
{
    [JsonIgnore]
    public HistoryEventType EventType => HistoryEventType.DiIncomingRequest;
}