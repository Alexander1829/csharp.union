using System.Text.Json.Serialization;

namespace AppSample.Union.HistoryEvents.HistoryModule.Domain.Models.EventData.Idgw;

public record struct AuthChainStartResultEventData(
    [property: JsonPropertyName("rt")] AuthChainStartResultType Result) : IHistoryEventData
{
    [JsonIgnore]
    public HistoryEventType EventType => HistoryEventType.AuthChainStartResult;
}