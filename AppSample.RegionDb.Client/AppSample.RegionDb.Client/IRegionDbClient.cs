using AppSample.RegionDb.Client.Connected_Services.RegionDb;

namespace AppSample.RegionDb.Client;

public interface IRegionDbClient
{
    Task<RegionOperatorInfo?> GetInfoByMsisdnAsync(long msisdn);
}