using System.Text.Json.Serialization;

namespace AppSample.Union.HistoryEvents.HistoryModule.Domain.Models.EventData.Idgw;

public record struct AuthChainEndFailedEventData(
    [property: JsonPropertyName("at")] AuthenticatorType AuthenticatorType,
    [property: JsonPropertyName("rt")] AuthResult Result,
    [property: JsonPropertyName("rn")] string Reason) : IHistoryEventData
{
    [JsonIgnore]
    public HistoryEventType EventType => HistoryEventType.AuthChainEndFailed;
}