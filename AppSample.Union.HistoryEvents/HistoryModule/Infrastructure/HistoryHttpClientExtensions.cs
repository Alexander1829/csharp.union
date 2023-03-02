using AppSample.Union.HistoryEvents.HistoryModule.Domain;
using AppSample.Union.HistoryEvents.HistoryModule.Presentation;

namespace AppSample.Union.HistoryEvents.HistoryModule.Infrastructure;

public static class HistoryHttpClientExtensions
{
    public static HttpClient AddDefaultTransactionId(this HttpClient httpClient)
    {
        if (Guid.Empty == TransactionInfo.TransactionId)
            return httpClient;

        httpClient.DefaultRequestHeaders.Add(HistoryEventsMiddleware.TransactionIdHeaderName,
            TransactionInfo.TransactionId.ToString());

        return httpClient;
    }
}