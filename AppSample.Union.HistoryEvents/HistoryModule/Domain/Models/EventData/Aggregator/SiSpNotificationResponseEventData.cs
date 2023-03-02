using System.Text.Json.Serialization;

namespace AppSample.Union.HistoryEvents.HistoryModule.Domain.Models.EventData.Aggregator;

public record struct SiSpNotificationResponseEventData(
    [property: JsonPropertyName("sc")] int StatusCode) : IHistoryEventData
{
    [JsonIgnore]
    public HistoryEventType EventType => HistoryEventType.SiSpNotificationResponse;
}