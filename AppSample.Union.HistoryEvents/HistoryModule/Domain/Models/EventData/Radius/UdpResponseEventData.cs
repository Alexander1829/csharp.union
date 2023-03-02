using System.Text.Json.Serialization;

namespace AppSample.Union.HistoryEvents.HistoryModule.Domain.Models.EventData.Radius;

public record struct UdpResponseEventData ([property: JsonPropertyName("r")] bool Success) : IHistoryEventData
{
	[JsonIgnore]
	public HistoryEventType EventType => HistoryEventType.UdpResponse;

}