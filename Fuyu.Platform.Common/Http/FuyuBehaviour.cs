using System.Text;
using Fuyu.Platform.Common.Compression;

namespace Fuyu.Platform.Common.Http
{
    public abstract class FuyuBehaviour
    {
        public abstract void Run(FuyuContext context);

        public static void Send(FuyuContext context, byte[] data, string mime, bool zipped = true)
        {
            var response = context.Response;

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

        public static void SendJson(FuyuContext context, string text, bool zipped = true)
        {
            var data = Encoding.UTF8.GetBytes(text);
            Send(context, data, "application/json; charset=utf-8", zipped);
        }

        public static void Close(FuyuContext context)
        {
            context.Response.Close();
        }
    }
}