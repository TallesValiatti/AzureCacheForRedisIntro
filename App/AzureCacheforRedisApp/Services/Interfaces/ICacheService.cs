namespace AzureCacheforRedisApp.Services.Interfaces
{
    public interface ICacheService
    {
         Task SetAsync<T>(string key, T value, TimeSpan absolutTimeToExpire);
         Task<T?> GetAsync<T>(string key);
    }
}