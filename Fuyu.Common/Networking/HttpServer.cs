using System;
using System.Net;
using System.Threading;
using Fuyu.Common.IO;

namespace Fuyu.Common.Networking
{
    public class HttpServer
    {
        private readonly HttpListener _listener;
        private readonly Thread _onRequest;
        public readonly HttpRouter HttpRouter;
        public readonly string Address;
        public readonly string Name;

        public HttpServer(string name, string address)
        {
            HttpRouter = new HttpRouter();
            Address = address;
            Name = name;

            _listener = new HttpListener();
            _listener.Prefixes.Add(address);

            _onRequest = new Thread(OnRequest);
        }

        private void OnRequest()
        {
            Thread.CurrentThread.IsBackground = true;

            while (_listener.IsListening)
            {
                var httpvContext = _listener.GetContext();
                var context = new HttpContext(httpvContext.Request, httpvContext.Response);

                Terminal.WriteLine($"[{Name}] {context.Path}");

                try
                {
                    HttpRouter.Route(context);
                }
                catch (Exception ex)
                {
                    Terminal.WriteLine(ex.Message);
                    context.Response.Close();
                }
            }
        }

        public virtual void RegisterServices()
        {
            // intentionally left empty
        }

        public void Start()
        {
            _listener.Start();
            _onRequest.Start();

            Terminal.WriteLine($"[{Name}] Started on {Address}");
        }

        public void AddHttpController<T>() where T : HttpController, new()
        {
            HttpRouter.Controllers.Add(new T());
        }
    }
}