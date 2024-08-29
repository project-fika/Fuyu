using System.IO;
using System.Text;
using Fuyu.Platform.Common.Compression;
using Fuyu.Platform.Common.Serialization;
using WebSocketSharp.Net;

namespace Fuyu.Platform.Common.Http
{
    public class FuyuContext
    {
        public readonly HttpListenerRequest Request;
        public readonly HttpListenerResponse Response;

        public FuyuContext(HttpListenerRequest request, HttpListenerResponse response)
        {
            Request = request;
            Response = response;
        }

        public string GetPath()
        {
            var path = Request.Url.PathAndQuery;

            if (path.Contains("?"))
            {
                path = path.Split('?')[0];
            }

            return path;
        }

        public bool HasBody()
        {
            return Request.HasEntityBody;
        }

        public byte[] GetBody()
        {
            using (var ms = new MemoryStream())
            {
                Request.InputStream.CopyTo(ms);
                var body = ms.ToArray();

                if (Zlib.IsCompressed(body))
                {
                    body = Zlib.Decompress(body);
                }

                return body;
            }
        }

        public string GetText()
        {
            var body = GetBody();
            return Encoding.UTF8.GetString(body);
        }

        public T GetJson<T>()
        {
            var json = GetText();
            return Json.Parse<T>(json);
        }

        public string GetSessionId()
        {
            return Request.Cookies["PHPSESSID"].Value;
        }
    }
}