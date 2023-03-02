using System.Text.Json.Serialization;

namespace AppSample.Union.HistoryEvents.HistoryModule.Domain.Models.EventData.Radius;

public record struct AggregatorSiAuthorizationRequestEventData([property: JsonPropertyName("m")] string Msisdn) : IHistoryEventData
{
	[JsonIgnore]
	public HistoryEventType EventType => HistoryEventType.AggregatorSiAuthorizeRequest;
}