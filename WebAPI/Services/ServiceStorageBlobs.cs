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
            await folder.DeleteBlobIfExistsAsync(blobName, DeleteSnapshotsOption.None);
        }

        public async Task<List<string>> GetBlobsAsync(string containerName)
        {
            BlobContainerClient folder = _client.GetBlobContainerClient(containerName);
            List<string> imagesList = new List<string>();
            await foreach (BlobItem image in folder.GetBlobsAsync())
            {
                imagesList.Add(image.Name);
            }
            return imagesList;
        }

        public async Task UploadBlobAsync(string containerName, string blobName, Stream stream)
        {
            BlobContainerClient containerClient = _client.GetBlobContainerClient(containerName);
            BlobClient blobClient = containerClient.GetBlobClient(blobName);
            await blobClient.UploadAsync(stream, overwrite: true);
        }

        /*public async Task<bool> BlobExists(string containerName, string blobName)
        {
            BlobContainerClient folder = _client.GetBlobContainerClient(containerName);
            return await folder.DeleteBlobIfExistsAsync(blobName,DeleteSnapshotsOption.None);
            
        }
        */
    }
}
