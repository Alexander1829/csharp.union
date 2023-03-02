namespace AppSample.Union.HistoryEvents.HistoryModule.Domain.Models;

public static class EnumCollections
{
    /// <summary>
    /// Список типов событий, содержащих MSISDN
    /// </summary>
    public static HashSet<HistoryEventType> MsisdnEventTypes => new HashSet<HistoryEventType>()
    {
        HistoryEventType.DiMsisdnRegistered,
        HistoryEventType.DiMsisdnSpecified,
        HistoryEventType.SiMsisdnRegistered
    };
}