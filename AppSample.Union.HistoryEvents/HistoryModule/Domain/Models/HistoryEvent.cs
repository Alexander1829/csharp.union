namespace AppSample.Union.HistoryEvents.HistoryModule.Domain.Models;

record struct HistoryEvent(
    ComponentType ComponentId,
    HistoryEventType EventType,
    Guid TransactionId,
    DateTimeOffset EventDate,
    string? ClientId,
    string? EventValue);