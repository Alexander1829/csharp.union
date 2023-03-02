namespace AppSample.Union.HistoryEvents.HistoryModule.Domain.Models;

public interface IHistoryEventData
{
    HistoryEventType EventType { get; }
}