using System;
using WebSocketSharp.Server;
using Fuyu.Common.IO;

namespace Fuyu.Common.Networking
{
    public class HttpServer
    {
        private readonly WebSocketSharp.Server.HttpServer _httpv;
        public readonly HttpRouter HttpRouter;
        public readonly string Address;
        public readonly string Name;

        public HttpServer(string name, string address)
        {
            HttpRouter = new HttpRouter();
            Address = address;
            Name = name;

            var uri = new Uri(address);
            _httpv = new WebSocketSharp.Server.HttpServer(uri.Port);
            _httpv.OnGet += OnRequest;
            _httpv.OnPost += OnRequest;
            _httpv.OnPut += OnRequest;
        }

        private void OnRequest(object sender, HttpRequestEventArgs e)
        {
            var context = new HttpContext(e.Request, e.Response);

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
        }

        public void AddHttpController<T>() where T : HttpController, new()
        {
            HttpRouter.Controllers.Add(new T());
        }
    }
}