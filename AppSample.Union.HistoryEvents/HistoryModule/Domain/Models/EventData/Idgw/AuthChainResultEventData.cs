using System.Text.Json.Serialization;

namespace AppSample.Union.HistoryEvents.HistoryModule.Domain.Models.EventData.Idgw;

public record struct AuthChainResultEventData(
    [property: JsonPropertyName("at")] AuthenticatorType AuthenticatorType,
    [property: JsonPropertyName("rt")] AuthResult Result) : IHistoryEventData
{
    [JsonIgnore]
    public HistoryEventType EventType => HistoryEventType.AuthChainResult;
}