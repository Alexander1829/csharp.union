using System.Text.Json.Serialization;

namespace AppSample.Union.HistoryEvents.HistoryModule.Domain.Models.EventData.Aggregator;

public record struct SiIdgwResponseEventData(
    [property: JsonPropertyName("i")] IdgwType IdgwType,
    [property: JsonPropertyName("ci")] string ClientId,
    [property: JsonPropertyName("sc")] int StatusCode,
    [property: JsonPropertyName("e"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] string? Error,
    [property: JsonPropertyName("ed"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] string? ErrorDescription) : IHistoryEventData
{
    [JsonIgnore]
    public HistoryEventType EventType => HistoryEventType.SiIdgwResponse;
}