using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Fuyu.Common.Networking
{
    // NOTE: Don't dispose this, keep a reference for the lifetime of the
    //       application.
    public class HttpClient : IDisposable
    {
        protected System.Net.Http.HttpClient Httpv;
        protected string Address;
        protected int Retries;

        public HttpClient(string address, int retries = 3)
        {
            Address = address;
            Retries = retries;

            var handler = new HttpClientHandler
            {
                // set cookies in header instead
                UseCookies = false
            };

            Httpv = new System.Net.Http.HttpClient(handler);
        }

        protected virtual HttpRequestMessage GetNewRequest(HttpMethod method, string path)
        {
            return new HttpRequestMessage()
            {
                Method = method,
                RequestUri = new Uri(Address + path)
            };
        }

        protected virtual byte[] OnSendBody(byte[] body)
        {
            return body;
        }

        protected virtual byte[] OnReceiveBody(byte[] body)
        {
            return body;
        }

        protected async Task<HttpResponse> SendAsync(HttpMethod method, string path, byte[] data)
        {
            HttpResponseMessage response = null;

            using (var request = GetNewRequest(method, path))
            {
                if (data != null)
                {
                    // add payload to request
                    data = OnSendBody(data);
                    request.Content = new ByteArrayContent(data);
                }

                // send request
                response = await Httpv.SendAsync(request);
            }

            if (!response.IsSuccessStatusCode)
            {
                // response error
                throw new Exception($"Code {response.StatusCode}");
            }

            byte[] body;

            // grap response payload
            using (var ms = new MemoryStream())
            {
                using (var stream = await response.Content.ReadAsStreamAsync())
                {
                    await stream.CopyToAsync(ms);
                    body = ms.ToArray();
                }
            }

            // handle middleware
            body = OnReceiveBody(body);

            return new HttpResponse()
            {
                Status = (int)response.StatusCode,
                Body = body
            };
        }

        protected async Task<HttpResponse> SendWithRetriesAsync(HttpMethod method, string path, byte[] data)
        {
            var error = new Exception("Internal error");

            // NOTE: <= is intentional. 0 is send, 1/2/3 is retry
            for (var i = 0; i <= Retries; ++i)
            {
                try
                {
                    return await SendAsync(method, path, data);
                }
                catch (Exception ex)
                {
                    error = ex;
                }
            }

            throw error;
        }

        public async Task<HttpResponse> GetAsync(string path)
        {
            return await SendWithRetriesAsync(HttpMethod.Get, path, null);
        }

        public HttpResponse Get(string path)
        {
            return GetAsync(path)
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();
        }

        public async Task<HttpResponse> PostAsync(string path, byte[] data)
        {
            return await SendWithRetriesAsync(HttpMethod.Post, path, data);
        }

        public HttpResponse Post(string path, byte[] data)
        {
            return PostAsync(path, data)
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();
        }

        public async Task<HttpResponse> PutAsync(string path, byte[] data)
        {
            return await SendWithRetriesAsync(HttpMethod.Put, path, data);
        }

        public HttpResponse Put(string path, byte[] data)
        {
            return PutAsync(path, data)
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();
        }

        public void Dispose()
        {
            Httpv.Dispose();
        }
    }
}