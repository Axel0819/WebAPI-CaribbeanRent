using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace WebAPI.Services
{
    public class ServiceStorageBlobs
    {
        private BlobServiceClient _client;
        public ServiceStorageBlobs(BlobServiceClient client)
        {
            _client = client;
        }

        public async Task DeleteBlobAsync(string containerName, string blobName)
        {
            BlobContainerClient folder = _client.GetBlobContainerClient(containerName);
            await folder.DeleteBlobAsync(blobName);
        }

        public async Task<List<string>> GetBlobsAsync(string containerName)
        {
            BlobContainerClient folder = _client.GetBlobContainerClient(containerName);
            List<string> imagenes = new List<string>();
            await foreach (BlobItem images in folder.GetBlobsAsync())
            {
                imagenes.Add(images.Name);
            }
            return imagenes;
        }

        public async Task UploadBlobAsync(string containerName, string blobName, Stream stream)
        {
            BlobContainerClient containerClient = _client.GetBlobContainerClient(containerName);
            BlobClient blobClient = containerClient.GetBlobClient(blobName);
            await blobClient.UploadAsync(stream, overwrite: true);
        }
    }
}
