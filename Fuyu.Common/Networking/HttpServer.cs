using System;
using System.Net;
using Fuyu.Common.IO;

namespace Fuyu.Common.Networking
{
    public class HttpServer
    {
        private readonly HttpListener _httpv;
        public readonly HttpRouter HttpRouter;
        public readonly string Address;
        public readonly string Name;

        public HttpServer(string name, string address)
        {
            HttpRouter = new HttpRouter();
            Address = address;
            Name = name;

            _httpv = new HttpListener();
            _httpv.Prefixes.Add(address);
        }

        private void OnRequest()
        {
            var httpvContext = _httpv.GetContext();
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

        public virtual void RegisterServices()
        {
            // intentionally left empty
        }

        public void Start()
        {
            _httpv.Start();
            Terminal.WriteLine($"[{Name}] Started on {Address}");
            OnRequest();
        }

        public void AddHttpController<T>() where T : HttpController, new()
        {
            HttpRouter.Controllers.Add(new T());
        }
    }
}