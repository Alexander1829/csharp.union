using AppSample.CoreTools.Settings;

namespace AppSample.RegionDb.Client.Settings;

public class  RegionDbSettings:BaseSettings,IRegionDbSettings
{
    public string Url { get; set; }
}