using System;
using System.IO.Compression;
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
            // NOTE: CompressionLevel.SmallestSize does not exist in
            //       .NET 5 and below.
            // -- seionmoya, 2024-10-07

#if NET6_0_OR_GREATER
            var level = CompressionLevel.SmallestSize;
#else
            var level = CompressionLevel.Optimal;
#endif

            return MemoryZlib.Compress(body, level);
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