namespace AppSample.CoreTools.RedisSignal;

public interface IRedisSignalService
{
    /// <summary>
    /// обработчик изменения настроек системы
    /// </summary>
    event Action<string?>? OnStateChange;

    void SignalStateChange(string? key = null);
}