using System.Text.Json.Serialization;

namespace AppSample.Union.HistoryEvents.HistoryModule.Domain.Models.EventData.Radius;

public record struct UdpRequestEventData([property: JsonPropertyName("u")] string Username) : IHistoryEventData
{
	[JsonIgnore]
	public HistoryEventType EventType => HistoryEventType.UdpRequest;

}