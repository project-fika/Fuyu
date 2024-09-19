using System;
using System.Net.Http;
using Fuyu.Common.Compression;

namespace Fuyu.Common.Networking
{
    public class EftHttpClient : HttpClient
    {
        public readonly string Cookie;

        public EftHttpClient(string address, string sessionId) : base(address)
        {
            Cookie = $"PHPSESSID={sessionId}";
        }

        protected override byte[] OnSendBody(byte[] body)
        {
            return Zlib.Compress(body, ZlibCompression.Level9);
        }

        protected override byte[] OnReceiveBody(byte[] body)
        {
            if (Zlib.IsCompressed(body))
            {
                body = Zlib.Decompress(body);
            }

            return body;
        }

        protected override HttpRequestMessage GetNewRequest(HttpMethod method, string path)
        {
            var request = new HttpRequestMessage()
            {
                Method = method,
                RequestUri = new Uri(Address + path),
            };

            if (!string.IsNullOrWhiteSpace(Cookie))
            {
                request.Headers.Add("Cookie", Cookie);
            }

            return request;
        }
    }
}