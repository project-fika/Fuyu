using System;
using WebSocketSharp.Server;
using Fuyu.Platform.Common.IO;

namespace Fuyu.Platform.Common.Networking
{
    public class FuyuServer
    {
        private readonly HttpServer _httpv;
        public readonly FuyuHttpRouter HttpRouter;
        public readonly string Address;
        public readonly string Name;

        public FuyuServer(string name, string address)
        {
            HttpRouter = new FuyuHttpRouter();
            Address = address;
            Name = name;

            var uri = new Uri(address);
            _httpv = new HttpServer(uri.Port);
            _httpv.OnGet += OnRequest;
            _httpv.OnPost += OnRequest;
            _httpv.OnPut += OnRequest;
        }

        private void OnRequest(object sender, HttpRequestEventArgs e)
        {
            var context = new FuyuHttpContext(e.Request, e.Response);

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

        public void Start()
        {
            _httpv.Start();
            Terminal.WriteLine($"[{Name}] Started on {Address}");
        }

        public void AddHttpService<T>() where T : FuyuHttpBehaviour, new()
        {
            HttpRouter.Behaviours.Add(new T());
        }
    }
}