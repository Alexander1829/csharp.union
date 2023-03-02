using System.Text.Json.Serialization;

namespace AppSample.Union.HistoryEvents.HistoryModule.Domain.Models.EventData.Radius;

public record struct RadiusSessionBusyEventData() : IHistoryEventData
{
	[JsonIgnore]
	public HistoryEventType EventType => HistoryEventType.AggregatorAuthorizationResultChanged;
}