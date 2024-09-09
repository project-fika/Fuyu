using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Fuyu.Common.Compression;
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

        public void Close()
        {
            Response.Close();
        }
    }
}