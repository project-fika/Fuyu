using System.Collections.Generic;
using System.Text;
using Fuyu.Platform.Common.Compression;

namespace Fuyu.Platform.Common.Http
{
    public abstract class FuyuBehaviour
    {
        public readonly Dictionary<string, EFuyuArgument> Arguments;

        public FuyuBehaviour(string path)
        {
            Arguments = InitializeArguments(path);
        }

        private Dictionary<string, EFuyuArgument> InitializeArguments(string path)
        {
            var result = new Dictionary<string, EFuyuArgument>();
            var segments = path.Split('/');

            foreach (var segment in segments)
            {
                if (segment.StartsWith("{") && segment.EndsWith("}"))
                {
                    var name = segment.Trim('{', '}');
                    result.Add(name, EFuyuArgument.Dynamic);
                }
                else
                {
                    result.Add(segment, EFuyuArgument.Static);
                }
            }

            return result;
        }

        public bool IsMatch(FuyuContext context)
        {
            var segments = context.Path.Split('/');
            var i = 0;

            if (segments.Length != Arguments.Count)
            {
                // segment length does not match
                return false;
            }

            foreach (var kvp in Arguments)
            {
                // validate static segment
                if (kvp.Value == EFuyuArgument.Static && segments[i] != kvp.Key)
                {
                    return false;
                }

                ++i;
            }

            return true;
        }

        public abstract void Run(FuyuContext context);

        public static void Send(FuyuContext context, byte[] data, string mime, bool zipped = true)
        {
            var response = context.Response;

            // used for plaintext debugging
            if (context.Request.Headers["fuyu-debug"] != null)
            {
                zipped = true;
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