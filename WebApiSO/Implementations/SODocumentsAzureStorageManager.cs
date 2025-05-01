using Azure.Storage.Blobs;
using Azure.Storage.Sas;
using FSA.Core.Interfaces;

namespace WebApiSO.Implementations
{
    public class SODocumentsAzureStorageManager : IAzureStorageManager
    {
        private int defaultAtempts = 3;

        private BlobContainerClient? blobContainerClient;

        private bool online = true;

        public SODocumentsAzureStorageManager(IConfiguration configuration)
        {
            try
            {
                string blobContainerName = configuration.GetSection("AzureStorage")["SODocsContainerName"];
                string connectionString = configuration.GetSection("AzureStorage")["AzureStorageConnStr"];
                blobContainerClient = new BlobContainerClient(connectionString, blobContainerName);
                blobContainerClient.CreateIfNotExists();
            }
            catch (Exception)
            {
                online = false;
            }
        }
        public async Task<bool> DeleteDocumentAsync(string fileName)
        {
            int atempts = defaultAtempts;
            do
            {
                atempts--;
                try
                {
                    await blobContainerClient.DeleteBlobAsync(fileName);
                    return true;
                }
                catch (Exception)
                {
                }
            }
            while (atempts >= 0);
            return false;
        }

        public async Task<MemoryStream> DownloadDocumentAsync(string fileName)
        {
            int atempts = defaultAtempts;
            do
            {
                atempts--;
                try
                {
                    MemoryStream stream = new MemoryStream();
                    BlobClient blob = blobContainerClient.GetBlobClient(fileName);
                    await blob.DownloadToAsync(stream);
                    return stream;
                }
                catch (Exception)
                {
                }
            }
            while (atempts >= 0);
            return null;
        }

        public string GetSasUri(string fileName)
        {
            int num = defaultAtempts;
            do
            {
                num--;
                try
                {
                    DateTime now = DateTime.Now;
                    BlobClient blobClient = blobContainerClient.GetBlobClient(fileName);
                    return blobClient.GenerateSasUri(BlobSasPermissions.Read, now.AddDays(1.0)).AbsoluteUri;
                }
                catch (Exception)
                {
                }
            }
            while (num >= 0);
            return string.Empty;
        }

        public bool IsOnline()
        {
            return online;
        }

        public async Task<string> UploadDocumentFromStreamAsync(Stream stream, string fileName)
        {
            int atempts = defaultAtempts;
            do
            {
                atempts--;
                try
                {
                    await blobContainerClient.UploadBlobAsync(fileName, stream);
                    BlobClient blob = blobContainerClient.GetBlobClient(fileName);
                    return blob.Uri.AbsoluteUri;
                }
                catch (Exception)
                {
                }
            }
            while (atempts >= 0);
            return string.Empty;
        }

        public async Task<string> UploadDocumentFromStreamAsync(byte[] bytes, string fileName)
        {
            int atempts = defaultAtempts;
            do
            {
                atempts--;
                try
                {
                    await blobContainerClient.UploadBlobAsync(fileName, (Stream)new MemoryStream(bytes), default(CancellationToken));
                    BlobClient blob = blobContainerClient.GetBlobClient(fileName);
                    return blob.Uri.AbsoluteUri;
                }
                catch (Exception)
                {
                }
            }
            while (atempts >= 0);
            return string.Empty;
        }
    }
}
