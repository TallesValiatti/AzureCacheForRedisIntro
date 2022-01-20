using AzureCacheforRedisApp.Entities;
using AzureCacheforRedisApp.Services.Interfaces;
using System.Linq;

namespace AzureCacheforRedisApp.Services.Implementations
{
    public class CityService : ICityService
    {
        private readonly IFileService _fileService;
        public CityService(IFileService fileService)
        {
            _fileService = fileService;
        }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            var cities = new List<City>();
            var lines = await _fileService.ReadCsvFileAsync("Cities.csv");

            if(lines.Any())
            {
                foreach (var line in lines)
                {
                    var itens = line.Split(';');
                    cities.Add(new City(Convert.ToInt32(itens[0]), itens[1]));
                }
            }
            return cities;
        }
    }
}