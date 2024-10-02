using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Zlib.Managed;
using Fuyu.Common.Serialization;

namespace Fuyu.Common.Networking
{
    public class HttpContext : Context
    {
        public HttpContext(HttpListenerRequest request, HttpListenerResponse response) : base(request, response)
        {
        }

        public bool HasBody()
        {
            return Request.HasEntityBody;
        }

        public async Task<byte[]> GetBinaryAsync()
        {
            using (var ms = new MemoryStream())
            {
                await Request.InputStream.CopyToAsync(ms);
                var body = ms.ToArray();

                if (MemoryZlib.IsCompressed(body))
                {
                    body = MemoryZlib.Decompress(body);
                }

                return body;
            }
        }

        public async Task<string> GetTextAsync()
        {
            var body = await GetBinaryAsync();
            return Encoding.UTF8.GetString(body);
        }

        public async Task<T> GetJsonAsync<T>()
        {
            var json = await GetTextAsync();
            return Json.Parse<T>(json);
        }

        public string GetSessionId()
        {
            return Request.Cookies["PHPSESSID"].Value;
        }

        protected async Task SendAsync(byte[] data, string mime, HttpStatusCode status, bool zipped = true)
        {
            // used for plaintext debugging
            if (Request.Headers["fuyu-debug"] != null)
            {
                zipped = false;
            }

            if (zipped)
            {
                data = MemoryZlib.Compress(data, CompressionLevel.BestCompression);
            }

            Response.StatusCode = (int)status;
            Response.ContentType = mime;
            Response.ContentLength64 = data.Length;

            using (var payload = Response.OutputStream)
            {
                await payload.WriteAsync(data, 0, data.Length);
            }
        }

        public async Task SendStatus(HttpStatusCode status)
        {
            await SendAsync(null, "plain/text", status, false);
        }

        public async Task SendJsonAsync(string text, bool zipped = true)
        {
            var encoded = Encoding.UTF8.GetBytes(text);
            await SendAsync(encoded, "application/json; charset=utf-8", HttpStatusCode.Accepted, zipped);
        }

        public void Close()
        {
            Response.Close();
        }
    }
}