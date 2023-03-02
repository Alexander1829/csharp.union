using System.Text.Json.Serialization;

namespace AppSample.Union.HistoryEvents.HistoryModule.Domain.Models.EventData.Idgw;

public record struct AuthenticatorStartResultEventData(
    [property: JsonPropertyName("at")] AuthenticatorType AuthenticatorType,
    [property: JsonPropertyName("rt")] AuthenticatorStartResultType Result) : IHistoryEventData
{
    [JsonIgnore]
    public HistoryEventType EventType => HistoryEventType.AuthenticatorStartResult;
}