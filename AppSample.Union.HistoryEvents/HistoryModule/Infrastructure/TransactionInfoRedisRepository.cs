using AppSample.Union.HistoryEvents.HistoryModule.Domain;
using StackExchange.Redis;

namespace AppSample.Union.HistoryEvents.HistoryModule.Infrastructure;

public interface ITransactionInfoRepository
{
    public Task CaptureTransactionIdAsync(string msisdn);
    public Task CaptureTransactionIdAsync(string msisdn, TimeSpan expireIn);
    public Task<Guid> RestoreTransactionIdAsync(string msisdn);
    public Task CaptureTransactionIdAsync(Guid key);
    public Task CaptureTransactionIdAsync(Guid key, TimeSpan expireIn);
    public Task<Guid> RestoreTransactionIdAsync(Guid key);
}

public class TransactionInfoRedisRepository : ITransactionInfoRepository
{
    static string GetRedisKey(Guid key) => $"history-events-transaction-id:{key.ToString()}";
    static string GetRedisKey(string msisdn) => $"history-events-transaction-id:{msisdn}";
    
    readonly IConnectionMultiplexer _redisConnection;

    public TransactionInfoRedisRepository(IConnectionMultiplexer redisConnection)
    {
        _redisConnection = redisConnection;
    }

    public async Task CaptureTransactionIdAsync(string msisdn) => await CaptureTransactionIdCoreAsync(GetRedisKey(msisdn), TimeSpan.FromDays(1));
    public async Task CaptureTransactionIdAsync(string msisdn, TimeSpan expireIn) => await CaptureTransactionIdCoreAsync(GetRedisKey(msisdn), expireIn);

    public async Task<Guid> RestoreTransactionIdAsync(string msisdn) => await RestoreTransactionIdCoreAsync(GetRedisKey(msisdn));
    public async Task CaptureTransactionIdAsync(Guid key) => await CaptureTransactionIdCoreAsync(GetRedisKey(key), TimeSpan.FromDays(1));
    public async Task CaptureTransactionIdAsync(Guid key, TimeSpan expireIn) => await CaptureTransactionIdCoreAsync(GetRedisKey(key), expireIn);
    public async Task<Guid> RestoreTransactionIdAsync(Guid key) => await RestoreTransactionIdCoreAsync(GetRedisKey(key));
    
    async Task CaptureTransactionIdCoreAsync(string redisKey, TimeSpan expireIn)
    {
        var db = _redisConnection.GetDatabase();
        await db.StringSetAsync(redisKey, TransactionInfo.TransactionId.ToString(), expireIn);
    }
    
    async Task<Guid> RestoreTransactionIdCoreAsync(string redisKey)
    {
        var db = _redisConnection.GetDatabase();
        var transactionIdStr = await db.StringGetAsync(redisKey);

        return Guid.TryParse(transactionIdStr, out var transactionId) ? transactionId : Guid.Empty;
    }
}