namespace AppSample.CoreTools.CachedConfig;

public interface IBaseCachedConfigService<TConfig> where TConfig : class
{
    TConfig GetState();
    void SignalChange(bool resetState = false);
}