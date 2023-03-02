using System.Text.Json.Serialization;

namespace AppSample.Union.HistoryEvents.HistoryModule.Domain.Models.EventData.Radius;

public record struct AggregatorAuthorizationFinalResponse(
	[property: JsonPropertyName("s")] string Status) : IHistoryEventData
{
	[JsonIgnore]
	public HistoryEventType EventType => HistoryEventType.AggregatorAuthorizationResultChanged;
}