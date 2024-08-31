using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebSocketSharp.Server;
using Fuyu.Platform.Common.IO;

namespace Fuyu.Platform.Common.Http
{
    public class FuyuServer
    {
        private readonly HttpServer _httpv;
        public readonly List<FuyuBehaviour> Behaviours;
        public readonly FuyuBehaviour OnError; 
        public readonly string Address;
        public readonly string Name;

        public FuyuServer(string name, string address)
        {
            var uri = new Uri(address);

            Address = address;
            Name = name;

            Behaviours = new List<FuyuBehaviour>();

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

            // NOTE: multi-threaded lookup
            var matches = new ConcurrentBag<FuyuBehaviour>();

            Parallel.ForEach(Behaviours, (behaviour) =>
            {
                if (behaviour.IsMatch(context))
                {
                    matches.Add(behaviour);
                }
            });

            if (matches.Count == 0)
            {
                Terminal.WriteLine($"No match on path {path}");
                context.Response.Close();
                return;
            }

            // NOTE: do we want to support multi-matching?
            if (matches.Count > 1)
            {
                Terminal.WriteLine($"Too many matches on path {path}");
                context.Response.Close();
                return;
            }

            foreach (var match in matches)
            {
                match.Run(context);
            }
        }

        public void Start()
        {
            _httpv.Start();
            Terminal.WriteLine($"[{Name}] Started on {Address}");
        }

        public void AddHttpService<T>() where T : FuyuBehaviour, new()
        {
            Behaviours.Add(new T());
        }
    }
}