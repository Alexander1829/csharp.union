using System.Text.Json.Serialization;

namespace AppSample.Union.HistoryEvents.HistoryModule.Domain.Models.EventData.Radius;

public record struct CloudConfigurationResponseEventData(
	[property: JsonPropertyName("c")] string ClientId) : IHistoryEventData
{
	[JsonIgnore]
	public HistoryEventType EventType => HistoryEventType.CloudConfigurationResponse;
}