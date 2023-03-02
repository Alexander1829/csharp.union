using AppSample.Union.HistoryEvents.HistoryModule.Domain;
using AppSample.Union.HistoryEvents.HistoryModule.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace AppSample.Union.HistoryEvents.HistoryModule.Presentation;

public static class HistoryServiceCollectionExtensions
{
    public static void AddHistoryBackgroundService(this IServiceCollection services,
        IConfigurationSection historyConfig)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        services.Configure<HistoryServiceSettings>(historyConfig);
        services.AddHostedService<EventsBackgroundService>();
    }

    public static void AddHistoryTransactionRedisRepository(this IServiceCollection services,
        Func<IServiceProvider, IConnectionMultiplexer> connectionGenerator)
    {
        if (connectionGenerator == null)
            throw new AggregateException("I need ConnectionGenerator");

        services.AddSingleton(connectionGenerator);
        services.AddSingleton<ITransactionInfoRepository, TransactionInfoRedisRepository>();
    }

    public static void AddHistoryTransactionRedisRepository(this IServiceCollection services,
        IConnectionMultiplexer redisConnection)
    {
        if (redisConnection == null)
            throw new AggregateException("I need IConnectionMultiplexer");

        services.AddSingleton(redisConnection);
        services.AddSingleton<ITransactionInfoRepository, TransactionInfoRedisRepository>();
    }
}