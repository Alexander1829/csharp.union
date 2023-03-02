using System.Text.Json.Serialization;

namespace AppSample.Union.HistoryEvents.HistoryModule.Domain.Models.EventData.Aggregator;

public record struct McTokenInternalResponseEventData([property: JsonPropertyName("sc")] int StatusCode) : IHistoryEventData
{
    [JsonIgnore]
    public HistoryEventType EventType => HistoryEventType.McTokenInternalResponse;
}
