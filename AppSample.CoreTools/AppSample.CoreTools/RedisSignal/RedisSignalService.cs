using AppSample.CoreTools.Redis;
using Microsoft.Extensions.Logging;

namespace AppSample.CoreTools.RedisSignal;

public class RedisSignalService : IRedisSignalService
{
    readonly IRedisService _redisService;
    readonly ILogger<RedisSignalService> _logger;

    const string ChannelName = "State";

    public RedisSignalService(IRedisService redisService, ILogger<RedisSignalService> logger)
    {
        _redisService = redisService;
        _logger = logger;

        _redisService.Subscribe(ChannelName, StateCallback);
    }

    void StateCallback(string? message)
    {
        try
        {
            _logger.LogDebug("StateCallback: message=" + message);
            OnStateChange?.Invoke(message);
        }
        catch (Exception exp)
        {
            _logger.LogError(exp, "Error in StateCallback()");
        }
    }

    public event Action<string?>? OnStateChange;

    public void SignalStateChange(string? key = null)
    {
        key ??= Guid.NewGuid().ToString();
        _redisService.Publish(ChannelName, key);
    }
}