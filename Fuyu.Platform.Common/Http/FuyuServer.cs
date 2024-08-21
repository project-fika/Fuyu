using System;
using System.Collections.Generic;
using WebSocketSharp.Server;
using Fuyu.Platform.Common.IO;

namespace Fuyu.Platform.Common.Http
{
    public class FuyuServer
    {
        private readonly HttpServer _httpv;
        public readonly Dictionary<string, FuyuBehaviour> Behaviours;
        public readonly FuyuBehaviour OnError; 
        public readonly string Address;
        public readonly string Name;

        public FuyuServer(string name, string address)
        {
            var uri = new Uri(address);

            Address = address;
            Name = name;

            Behaviours = new Dictionary<string, FuyuBehaviour>();
            OnError = new ErrorBehaviour();

            _httpv = new HttpServer(uri.Port);
            _httpv.OnGet += OnRequest;
            _httpv.OnPost += OnRequest;
            _httpv.OnPut += OnRequest;
        }

        private void OnRequest(object sender, HttpRequestEventArgs e)
        {
            var context = new FuyuContext(e.Request, e.Response);
            var path = context.GetPath();

            Terminal.WriteLine($"[{Name}] {path}");

            if (Behaviours.ContainsKey(path))
            {
                Behaviours[path].Run(context);
            }
            else
            {
                OnError.Run(context);
            }
        }

        public void Start()
        {
            _httpv.Start();
            Terminal.WriteLine($"[{Name}] Started on {Address}");
        }

        public void AddHttpService<T>(string path) where T : FuyuBehaviour, new()
        {
            Behaviours.Add(path, new T());
        }
    }
}