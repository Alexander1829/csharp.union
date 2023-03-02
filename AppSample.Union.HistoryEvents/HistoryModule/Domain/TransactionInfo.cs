namespace AppSample.Union.HistoryEvents.HistoryModule.Domain;

public static class TransactionInfo
{
    static readonly AsyncLocal<Guid> TransactionIdAsyncLocal = new();

    public static Guid TransactionId => TransactionIdAsyncLocal.Value;

    public static void SetTransactionId(Guid transactionId)
    {
        // годится без контроля многопоточности,
        // т.к. контекст исполнения копируется между потоками,
        // соответственно одновременный доступ невозможен
        
        TransactionIdAsyncLocal.Value = transactionId;
    }

    public static void SetTransactionIdIfNotSet(Guid transactionId)
    {
        if (TransactionIdAsyncLocal.Value == Guid.Empty)
        {
            TransactionIdAsyncLocal.Value = transactionId;
        }
    }
}