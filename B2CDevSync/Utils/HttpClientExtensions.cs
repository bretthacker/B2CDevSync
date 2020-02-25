using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace B2CDevSync.Utils
{
    public static class HttpClientExtensions
    {
        public static async Task DownloadAsync(this HttpClient client, string requestUri, Stream destination, IProgress<int> progress = null, CancellationToken cancellationToken = default)
        {
            //hack to try and coerce GitHub into giving us the file size
            //long? contentLength=0;
            //int counter = 0;
            //HttpResponseMessage header;
            //while (contentLength == 0 && counter < 10)
            //{
            //    counter++;
            //    header = await client.SendAsync(new HttpRequestMessage(HttpMethod.Head, requestUri));
            //    contentLength = header.Content.Headers.ContentLength;
            //    Thread.Sleep(50);
            //}

            using (var response = await client.GetAsync(requestUri, HttpCompletionOption.ResponseHeadersRead))
            {
                using (var download = await response.Content.ReadAsStreamAsync())
                {
                    // Ignore progress reporting when no progress reporter was 
                    // passed or when the content length is unknown
                    //if (progress == null || !contentLength.HasValue || contentLength.Value==0)
                    //{
                        progress.Report(-1);
                        await download.CopyToAsync(destination);
                        progress.Report(100);
                        return;
                    //}

                    //var relativeProgress = new Progress<long>(totalBytes => progress.Report((int)(((float)totalBytes / (float)contentLength.Value) * 100)));
                    //// Use extension method to report progress while downloading
                    //await download.CopyToAsync(destination, 81920, relativeProgress, cancellationToken);
                    //progress.Report(100);
                }
            }
        }
    }

    public static class StreamExtensions
    {
        public static async Task CopyToAsync(this Stream source, Stream destination, int bufferSize, IProgress<long> progress = null, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (!source.CanRead)
                throw new ArgumentException("Has to be readable", nameof(source));
            if (destination == null)
                throw new ArgumentNullException(nameof(destination));
            if (!destination.CanWrite)
                throw new ArgumentException("Has to be writable", nameof(destination));
            if (bufferSize < 0)
                throw new ArgumentOutOfRangeException(nameof(bufferSize));

            var buffer = new byte[bufferSize];
            long totalBytesRead = 0;
            int bytesRead;
            while ((bytesRead = source.Read(buffer, 0, buffer.Length)) != 0)
            {
                await destination.WriteAsync(buffer, 0, bytesRead, cancellationToken).ConfigureAwait(false);
                totalBytesRead += bytesRead;
                progress?.Report(totalBytesRead);
            }
        }
    }
}
