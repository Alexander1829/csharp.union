using System.Text.Json.Serialization;

namespace AppSample.Union.HistoryEvents.HistoryModule.Domain.Models.EventData.Aggregator;

public record struct SiIdgwNotificationEventData(
    [property: JsonPropertyName("i")] IdgwType IdgwType,
    [property: JsonPropertyName("r")] bool Success,
    [property: JsonPropertyName("e"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] string? Error,
    [property: JsonPropertyName("ed"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] string? ErrorDescription) : IHistoryEventData
{
    [JsonIgnore]
    public HistoryEventType EventType => HistoryEventType.SiIdgwNotification;
}