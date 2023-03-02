using System.Text.Json.Serialization;

namespace AppSample.Union.HistoryEvents.HistoryModule.Domain.Models.EventData.Radius;

public record struct CloudConfigurationRequestEventData([property: JsonPropertyName("ip")] string Ip) : IHistoryEventData
{
	[JsonIgnore]
	public HistoryEventType EventType => HistoryEventType.CloudConfigurationRequest;
}