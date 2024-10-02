using System;
using System.Net.Http;
using Zlib.Managed;

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
            return MemoryZlib.Compress(body, CompressionLevel.BestCompression);
        }

        protected override byte[] OnReceiveBody(byte[] body)
        {
            if (MemoryZlib.IsCompressed(body))
            {
                body = MemoryZlib.Decompress(body);
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