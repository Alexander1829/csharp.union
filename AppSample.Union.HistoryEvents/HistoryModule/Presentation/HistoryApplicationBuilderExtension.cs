using Microsoft.AspNetCore.Builder;

namespace AppSample.Union.HistoryEvents.HistoryModule.Presentation;

public static class HistoryApplicationBuilderExtension
{
    /// <summary>
    /// Регистрирует middleware, которое при наличии заголовка Transaction-Id во входящих HTTP-запросах
    /// устанавливает его значение в качестве сквозного идентификатора для последующих событий
    /// </summary>
    public static IApplicationBuilder UseHistoryEvents(this IApplicationBuilder app) =>
        app.UseMiddleware<HistoryEventsMiddleware>();
}