using System.Collections.Generic;
using System.Text;
using Fuyu.Platform.Common.Compression;

namespace Fuyu.Platform.Common.Networking
{
    public abstract class HttpBehaviour
    {
        public readonly Dictionary<string, EPathSegment> Path;

        public HttpBehaviour(string path)
        {
            Path = InitializePath(path);
        }

        private static Dictionary<string, EPathSegment> InitializePath(string path)
        {
            var result = new Dictionary<string, EPathSegment>();
            var segments = path.Split('/');

            foreach (var segment in segments)
            {
                if (segment.StartsWith("{") && segment.EndsWith("}"))
                {
                    var name = segment.Trim('{', '}');
                    result.Add(name, EPathSegment.Dynamic);
                }
                else
                {
                    result.Add(segment, EPathSegment.Static);
                }
            }

            return result;
        }

        public bool IsMatch(HttpContext context)
        {
            var segments = context.Path.Split('/');
            var i = 0;

            if (segments.Length != Path.Count)
            {
                // segment length does not match
                return false;
            }

            foreach (var kvp in Path)
            {
                // validate static segment
                if (kvp.Value == EPathSegment.Static && segments[i] != kvp.Key)
                {
                    return false;
                }

                ++i;
            }

            return true;
        }

        public abstract void Run(HttpContext context);

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
            var data = Encoding.UTF8.GetBytes(text);
            Send(context, data, "application/json; charset=utf-8", zipped);
        }

        public static void Close(HttpContext context)
        {
            context.Response.Close();
        }
    }
}