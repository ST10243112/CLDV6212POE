namespace ABCRetail.Services
{
    public interface IAzureStorageService
    {
        //table operations
        Task<List<T>> GetAllEntitiesAsync<T>() where T : class, Azure.Data.Tables.ITableEntity, new();

        Task<T?> GetEntityAsync<T>(string partitionKey, string rowKey) where T : class, Azure.Data.Tables.ITableEntity, new();

        Task<T> AddEntityAsync<T>(T entity) where T : class, Azure.Data.Tables.ITableEntity;

        Task<T> UpdateEntityAsync<T>(T entity) where T : class, Azure.Data.Tables.ITableEntity;

        Task DeleteEntityAsync<T>(string partitionKey, string rowKey) where T: class, Azure.Data.Tables.ITableEntity, new();


        //Blob specific operations 
        Task<string> UploadImageAsync(IFormFile file, string conttainerName);
        Task<string> UploadFileAsync(IFormFile file, string conttainerName);
        Task DeleteBlobAsync(string blobName, string conttainerName);

        //Queue Operations 
        Task SendMessageAsync(string queueName, string message);
        Task<string?> ReceiveMessageAsync(string queueName);

        //File share operations
        Task<string> UploadToFileShareAsync(IFormFile file, string shareName, string directoryName = "");

        Task<byte[]> DownloadFromFileShareAsync(string shareName, string FileName, string directoryName = "");
    }
}
