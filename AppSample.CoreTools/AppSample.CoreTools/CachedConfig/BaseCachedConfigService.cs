using AppSample.CoreTools.Helpers;
using AppSample.CoreTools.RedisSignal;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AppSample.CoreTools.CachedConfig;

public abstract class BaseCachedConfigService<TConfig>: IBaseCachedConfigService<TConfig>,IDisposable where TConfig : class
{
    volatile TConfig? _state;
    readonly IRedisSignalService _redisSignalService;
    readonly ILogger _logger;
    readonly TimeSpan _reloadPeriod;
    readonly IHostApplicationLifetime _hostLifetime;
    string _lastKey;

    readonly AutoResetEvent _signalEvent = new(true);
    readonly SemaphoreLocker _locker = new();

    protected BaseCachedConfigService(IRedisSignalService redisSignalSignalService, IHostApplicationLifetime hostLifetime,
        ILogger logger, TimeSpan reloadPeriod)
    {
        _redisSignalService = redisSignalSignalService;
        _logger = logger;
        if (reloadPeriod <= TimeSpan.Zero) throw new ArgumentOutOfRangeException(nameof(reloadPeriod));
        _reloadPeriod = reloadPeriod;
        _hostLifetime = hostLifetime;

        _hostLifetime.ApplicationStarted.Register(OnApplicationStart);

        _redisSignalService.OnStateChange += (key) =>
        {
            if (key != _lastKey) //игнорируем свой сигнал
            {
                _logger.LogDebug("Configuration change signal");
                _signalEvent.Set();
            }
        };
    }

    void OnApplicationStart()
    {
        _ = Task.Run(async () =>
        {
            try
            {
                await ReloadTask(_hostLifetime.ApplicationStopped);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp, "Error");
            }
        });
    }

    /// <summary>
    /// Выполнение перезагрузки
    /// </summary>
    /// <param name="ct"></param>
    /// <returns></returns>
    async Task ReloadTask(CancellationToken ct)
    {
        while (true)
        {
            if (ct.IsCancellationRequested) return;
            try
            {
                await Load(false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Load configuration error");
            }
            WaitHandle.WaitAny(new[] {ct.WaitHandle, _signalEvent}, _reloadPeriod); //ожидаем либо срабатывания остановки или сигнала об изменении
        }
    }

    /// <summary>
    /// Возвращается последнее полученное состояние.
    /// Если его нет - то выполняется загрузка состояния. В этом случае может быть выброшено исключение.
    /// </summary>
    /// <returns></returns>
    public TConfig GetState()
    {
        return _state ?? AsyncHelper.RunSync(() => Load(true));
    }

    /// <summary>
    /// Передача сигнала в Redis о изменении состояния
    /// </summary>
    public void SignalChange(bool resetState = false)
    {
        if (resetState)
        {
            _state = null;
        }
        
        var key = Guid.NewGuid().ToString();
        _lastKey = key;
        _signalEvent.Set();
        _redisSignalService.SignalStateChange(key);
    }

    /// <summary>
    /// Метод загрузки состояния из источника
    /// </summary>
    /// <returns></returns>
    protected abstract Task<TConfig> LoadStateFromSource();

    /// <summary>
    /// Загрузка состояния. Может быть выброшено исключение.
    /// </summary>
    /// <returns></returns>
    async Task<TConfig> Load(bool onlyFirstLoad)
    {
        return await _locker.LockAsync(async () =>
        {
            if (onlyFirstLoad == false || _state == null)
            {
                _logger.LogDebug("Loading configuration");
                _state = await LoadStateFromSource();
            }
            return _state;
        });
    }

    public void Dispose()
    {
        _signalEvent.Dispose();
        _locker.Dispose();
    }
}