using WebAPI.Services;

namespace WebAPI.Helpers
{
    public class ImageHelper
    {
        public static async Task<string> UploadHelper(ServiceStorageBlobs _service, string containerName, IFormFile file)
        {
            string extension = file.FileName.Split(".")[1];
            string fileName = Guid.NewGuid().ToString() + "." + extension;

            using (Stream stream = file.OpenReadStream())
            {
                await _service.UploadBlobAsync(containerName, fileName, stream);
            }

            return fileName;
        }
    }
}
