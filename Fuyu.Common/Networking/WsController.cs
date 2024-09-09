using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Fuyu.Common.Compression;

namespace Fuyu.Common.Networking
{
    public abstract class WsController : Controller
    {
        public WsController(string path) : base(path)
        {
        }

        public abstract Task RunAsync(WsContext context);

        public static void Send(HttpContext context, byte[] data, string mime, bool zipped = true)
        {
            var response = context.Response;

            // used for plaintext debugging
            if (context.Request.Headers["fuyu-debug"] != null)
            {
                zipped = false;
            }

            if (zipped)
            {
                data = Zlib.Compress(data, ZlibCompression.Level9);
            }

            response.ContentType = mime;
            response.ContentLength64 = data.Length;

            using (var payload = response.OutputStream)
            {
                payload.Write(data, 0, data.Length);
            }
        }

        public static void SendJson(HttpContext context, string text, bool zipped = true)
        {
            var encoded = Encoding.UTF8.GetBytes(text);
            Send(context, encoded, "application/json; charset=utf-8", zipped);
        }
    }
}