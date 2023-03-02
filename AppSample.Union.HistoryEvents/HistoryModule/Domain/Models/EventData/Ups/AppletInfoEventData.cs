using System.Text.Json.Serialization;

namespace AppSample.Union.HistoryEvents.HistoryModule.Domain.Models.EventData.Ups;

public record struct AppletInfoEventData(
    [property: JsonPropertyName("t")] AppletTypeEventData AppletType,
    [property: JsonPropertyName("v")] string Version,
    [property: JsonPropertyName("en")] bool IsEnabled
);