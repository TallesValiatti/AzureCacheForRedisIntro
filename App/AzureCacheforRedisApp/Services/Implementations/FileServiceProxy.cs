using AzureCacheforRedisApp.Services.Interfaces;
namespace AzureCacheforRedisApp.Services.Implementations
{
    public class FileServiceProxy : IFileService
    {
        private readonly ICacheService _cacheService;
        private readonly IFileService _fileService;
        private ILogger<FileServiceProxy> _logger;
        private const string _key = "linesCityFile";
        private TimeSpan _absolutTimeToExpire = TimeSpan.FromSeconds(60);

        public FileServiceProxy(ICacheService cacheService, ILogger<FileServiceProxy> logger)
        {
            _cacheService = cacheService;
            _fileService = new FileService();
            _logger = logger;
        }
        public async Task<string[]> ReadCsvFileAsync(string fullPath)
        {
            string[]? cacheData = await _cacheService.GetAsync<string[]>(_key);
            
            if(cacheData is not null)
            {
                _logger.LogInformation("Fetching data from cache ...");
                return cacheData;
            }

            _logger.LogInformation("Fetching data from file ...");
            var data = await _fileService.ReadCsvFileAsync(fullPath);

            await _cacheService.SetAsync(_key, data, _absolutTimeToExpire);

            return data;
        }
    }
}
