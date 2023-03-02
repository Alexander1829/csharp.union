using System.Diagnostics;
using AppSample.Union.HistoryEvents.HistoryModule.Domain;
using Microsoft.AspNetCore.Http;

namespace AppSample.Union.HistoryEvents.HistoryModule.Presentation;

/// <summary>
/// При наличии заголовка Transaction-Id или query-параметра transaction_id во входящих HTTP-запросах
/// устанавливает его значение в качестве сквозного идентификатора для последующих событий
/// </summary>
public class HistoryEventsMiddleware
{
    public const string TransactionIdHeaderName = "Transaction-Id";
    public const string TransactionIdQueryParamerName = "transaction_id";

    readonly RequestDelegate _next;

    public HistoryEventsMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var transactionId = GetTransactionIdFromHeader(context)
            ?? GetTransactionIdFromQueryParameters(context)
            ?? Guid.Empty;

        TransactionInfo.SetTransactionId(transactionId);

        if (TransactionInfo.TransactionId != Guid.Empty)
        {
            Activity.Current?.AddTag("mid.transaction_id", TransactionInfo.TransactionId);
        }

        await _next(context);
    }

    static Guid? GetTransactionIdFromHeader(HttpContext context)
    {
        var transactionIdStr = context.Request.Headers[TransactionIdHeaderName];

        return ParseGuid(transactionIdStr);
    }

    static Guid? GetTransactionIdFromQueryParameters(HttpContext context)
    {
        var transactionIdStr = context.Request.Query[TransactionIdQueryParamerName];

        return ParseGuid(transactionIdStr);
    }

    static Guid? ParseGuid(string? value) => Guid.TryParse(value, out var transactionId) ? transactionId : null;
}