using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.IO.Compression;

namespace PGK.Extensions.Web
{
    /// <summary>
    /// Extension methods for HttpListenerContext
    /// </summary>
    public static class HttpListenerContextExtensions
    {
        /// <summary>
        /// Prepare a response-stream using compression-, caching- and buffering-settings
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="allowZip">set to true in case you want to honor the compression-http-headers</param>
        /// <param name="buffered">set to true in case you want a BufferedStream</param>
        /// <param name="allowCache">set to false in case you want to set the no-cache-http-headers</param>
        /// <returns>the stream to write you stuff to</returns>
        public static Stream GetResponseStream(this HttpListenerContext context, bool allowZip = true, bool buffered = true, bool allowCache = true)
        {
            bool gzip = (context.Request.Headers["Accept-Encoding"] ?? String.Empty).Contains("gzip");
            bool deflate = (context.Request.Headers["Accept-Encoding"] ?? String.Empty).Contains("deflate");

            if (!allowCache)
            {
                context.Response.AddHeader("Date", DateTime.UtcNow.ToString("R"));
                context.Response.AddHeader("Expires", DateTime.UtcNow.AddHours(-1).ToString("R"));
                context.Response.AddHeader("Cache-Control", "no-cache");
                context.Response.AddHeader("Pragma", "no-cache");
            }

            Stream stream = context.Response.OutputStream;

            if (allowZip)
            {
                context.Response.AddHeader("Vary", "Accept-Encoding");
                if (gzip)
                {
                    stream = new GZipStream(stream, CompressionMode.Compress);
                    context.Response.AddHeader("Content-Encoding", "gzip");
                }
                else if (deflate)
                {
                    stream = new DeflateStream(stream, CompressionMode.Compress);
                    context.Response.AddHeader("Content-Encoding", "deflate");
                }
            }

            if (buffered)
                stream = new BufferedStream(stream);

            return stream;
        }
    }
}
