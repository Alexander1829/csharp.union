using System.Text.Json.Serialization;

namespace AppSample.Union.HistoryEvents.HistoryModule.Domain.Models.EventData.Ups;

public record struct GetUserProfileEventData(
    [property: JsonPropertyName("bl")] bool IsBlocked,
    [property: JsonPropertyName("ap")] IReadOnlyCollection<AppletInfoEventData>? Applets
) : IHistoryEventData
{
    [JsonIgnore]
    public HistoryEventType EventType => HistoryEventType.GetUserProfile;
}