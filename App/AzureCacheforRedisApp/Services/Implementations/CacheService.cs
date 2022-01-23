using System.Text.Json;
using AzureCacheforRedisApp.Services.Interfaces;
using Microsoft.Extensions.Caching.Distributed;

namespace AzureCacheforRedisApp.Services.Implementations
{
    public class CacheService : ICacheService
    {
        private readonly  IDistributedCache _cache;
        
        public CacheService(IDistributedCache cache)
        {
            _cache = cache;
        }
        public async Task<T?> GetAsync<T>(string key)
        {
            if(string.IsNullOrWhiteSpace(key))
                throw new Exception("Invalid key");

            var value = await _cache.GetStringAsync(key);
            
            if (string.IsNullOrWhiteSpace(value))
                return default;
           
            return JsonSerializer.Deserialize<T>(value);
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan absolutTimeToExpire)
        {
            if(string.IsNullOrWhiteSpace(key))
                throw new Exception("Invalid key");
            
            if(value is null)
                throw new Exception("Invalid value");

            DistributedCacheEntryOptions options = new DistributedCacheEntryOptions()
                                                       .SetAbsoluteExpiration(absolutTimeToExpire);
            
            await _cache.SetStringAsync(key, JsonSerializer.Serialize(value), options);
        }
    }
}
