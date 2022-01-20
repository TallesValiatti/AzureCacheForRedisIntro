namespace AzureCacheforRedisApp.Services.Interfaces
{
    public interface IFileService
    {
        Task<string[]> ReadCsvFileAsync(string fullPath);
    }
}