using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace B2CDevSync.Utils
{
    public class SyncStorage
    {
        public event EventHandler<FileCopyEventArgs> FileActivityMessage;
        protected virtual void OnFileActivity(FileCopyEventArgs e)
        {
            FileActivityMessage?.Invoke(this, e);
        }

        private CloudStorageAccount _account;
        private CloudBlobClient _client;
        private CloudBlobContainer _container;
        public string PathRoot { get; set; }

        /// <summary>
        /// Wrapper around the Azure Storage SDK for use by the sync tool
        /// </summary>
        /// <param name="connectionString">Azure storage connection string</param>
        /// <param name="containerName">Container to upload to</param>
        /// <param name="pathRoot">Root of local file system path, to help determine cloud paths below the container</param>
        public SyncStorage(string connectionString, string containerName, string pathRoot)
        {
            if (connectionString == "")
                return;

            PathRoot = pathRoot;
            _account = CloudStorageAccount.Parse(connectionString);
            _client = _account.CreateCloudBlobClient();
            _container = _client.GetContainerReference(containerName);
            _container.CreateIfNotExists();
        }

        public IEnumerable<IListBlobItem> GetBlobs()
        {
            return _container.ListBlobs(null, true, BlobListingDetails.None);
        }

        public CloudBlob GetBlob(string blobReference)
        {
            return _container.GetBlockBlobReference(blobReference);
        }

        public bool DeleteBlob(string fileName)
        {
            var blobName = fileName.Replace(PathRoot, "").ToLower(); ;
            blobName = blobName.TrimStart('\\');

            CloudBlockBlob blockBlob = _container.GetBlockBlobReference(blobName);

            // Delete the blob.
            var res = blockBlob.DeleteIfExists();

            OnFileActivity(new FileCopyEventArgs
            {
                FilePath = blockBlob.Uri.ToString(),
                Action = FileAction.Deleted
            });
            return res;
        }

        public async Task AddBlobAsync(string fileName)
        {
            var blobName = fileName.Replace(PathRoot, "").ToLower();
            blobName = blobName.TrimStart('\\');
            blobName = blobName.Replace("\\", "/");

            FileStream stream = null;
            try
            {
                stream = OpenShared(fileName);

                var blob = _container.GetBlockBlobReference(blobName);
                blob.Properties.ContentType = MimeMapping.GetMimeMapping(fileName);
                await blob.UploadFromStreamAsync(stream);

                OnFileActivity(new FileCopyEventArgs
                {
                    FilePath = fileName,
                    Action = FileAction.Uploaded
                });
            }
            catch (Exception)
            {
                throw;
            }

            finally
            {
                if (stream != null)
                {
                    stream.Close();
                    stream.Dispose();
                }
            }
        }

        public static FileStream OpenShared(string path)
        {
            FileStream stream = null;
            int count = 0;
            try
            {
                while (stream == null && count < 100)
                {
                    try
                    {
                        count++;
                        stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                    }
                    catch
                    {
                        Thread.Sleep(200);
                    }
                }

                if (stream == null)
                {
                    throw new Exception("Unable to read the file for uploading, waited 20 seconds...");
                }
            }
            catch (Exception)
            {
                throw;
            }

            return stream;
        }
    }

    public class FileCopyEventArgs : EventArgs
    {
        public string FilePath { get; set; }
        public FileAction Action { get; set; }
    }

    public enum FileAction
    {
        Uploaded,
        Deleted,
        PolicyUploaded,
        PolicyDeleted
    }
}