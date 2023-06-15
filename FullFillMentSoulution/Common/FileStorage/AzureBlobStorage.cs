using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Common.Model;
using Microsoft.Extensions.Configuration;

namespace Common.FileStorage
{
    public interface IFileStorageModule<TEntity>
    where TEntity : Entity
    {
        Task<string> UploadFileAsync(string entityId, string fileName, Stream fileStream);

        Task<Stream> DownloadFileAsync(string entityId, string fileName);

        Task DeleteFileAsync(string entityId, string fileName);
    }
    public class AzureBlobStorageModule<TEntity> : IFileStorageModule<TEntity>
    where TEntity : Entity
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly string _containerName;

        public AzureBlobStorageModule(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("AzureBlobStorageConnection");
            _containerName = configuration.GetValue<string>("AzureBlobStorageContainerName");
            _blobServiceClient = new BlobServiceClient(connectionString);
        }

        public async Task<string> UploadFileAsync(string entityId, string fileName, Stream fileStream)
        {
            BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
            BlobClient blobClient = containerClient.GetBlobClient(GetBlobName(entityId, fileName));

            await blobClient.UploadAsync(fileStream);

            return blobClient.Uri.ToString();
        }

        public async Task<Stream> DownloadFileAsync(string entityId, string fileName)
        {
            BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
            BlobClient blobClient = containerClient.GetBlobClient(GetBlobName(entityId, fileName));
            BlobDownloadInfo downloadInfo = await blobClient.DownloadAsync();
            return downloadInfo.Content;
        }

        public async Task DeleteFileAsync(string entityId, string fileName)
        {
            BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
            BlobClient blobClient = containerClient.GetBlobClient(GetBlobName(entityId, fileName));

            await blobClient.DeleteAsync();
        }

        private string GetBlobName(string entityId, string fileName)
        {
            return $"{typeof(TEntity).Name}/{entityId}/{fileName}";
        }
    }
}
