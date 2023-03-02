using System.Text.Json.Serialization;

namespace AppSample.Union.HistoryEvents.HistoryModule.Domain.Models.EventData.Radius;

public record struct DomainUsersRequestEventData([property: JsonPropertyName("u")] string Username) : IHistoryEventData
{
	[JsonIgnore]
	public HistoryEventType EventType => HistoryEventType.DomainUsersRequest;
}