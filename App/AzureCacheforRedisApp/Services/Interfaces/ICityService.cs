using AzureCacheforRedisApp.Entities;

namespace AzureCacheforRedisApp.Services.Interfaces
{
    public interface ICityService
    {
         Task<IEnumerable<City>> GetCitiesAsync();
    }
}