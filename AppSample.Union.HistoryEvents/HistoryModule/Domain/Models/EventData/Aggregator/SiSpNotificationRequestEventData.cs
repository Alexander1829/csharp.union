using System.Text.Json.Serialization;

namespace AppSample.Union.HistoryEvents.HistoryModule.Domain.Models.EventData.Aggregator;

public record struct SiSpNotificationRequestEventData(
	[property: JsonPropertyName("nu")] string NotificationUrl) : IHistoryEventData
{
	[JsonIgnore]
	public HistoryEventType EventType => HistoryEventType.SiSpNotificationRequest;
}