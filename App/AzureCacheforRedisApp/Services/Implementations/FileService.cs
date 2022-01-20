using AzureCacheforRedisApp.Services.Interfaces;

namespace AzureCacheforRedisApp.Services.Implementations
{
    public class FileService : IFileService
    {
        public async Task<string[]> ReadCsvFileAsync(string fullPath)
        {
            if(string.IsNullOrWhiteSpace(fullPath))
                throw new Exception("Invalid path");
            
            return await File.ReadAllLinesAsync(fullPath);
        }
    }
}