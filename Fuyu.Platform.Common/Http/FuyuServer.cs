using System;
using System.Collections.Generic;
using WebSocketSharp.Server;
using Fuyu.Platform.Common.IO;
using static Fuyu.Platform.Common.Http.DynamicFuyuBehaviour;
using System.Linq;

namespace Fuyu.Platform.Common.Http
{
    public class FuyuServer
    {
        private readonly HttpServer _httpv;
        public readonly Dictionary<string, FuyuBehaviour> Behaviours;
        public readonly List<DynamicFuyuBehaviour> DynamicBehaviours;
        public readonly FuyuBehaviour OnError; 
        public readonly string Address;
        public readonly string Name;

        public FuyuServer(string name, string address)
        {
            var uri = new Uri(address);

            Address = address;
            Name = name;

            Behaviours = new Dictionary<string, FuyuBehaviour>();
            DynamicBehaviours = new List<DynamicFuyuBehaviour>();
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

            FuyuBehaviour behaviour;
            // If we can get the behaviour then return it otherwise check dynamic behaviours,
            // if we still can't find any dynamic behaviour that can handle it then use OnError
            // I do believe you will hate this code but I'm confident I won't touch it again
            behaviour = Behaviours.TryGetValue(path, out behaviour) ? behaviour :
                        DynamicBehaviours.FirstOrDefault(d => d.CanHandle(path)) ?? OnError;
            behaviour.Run(context);
        }

        public void Start()
        {
            _httpv.Start();
            Terminal.WriteLine($"[{Name}] Started on {Address}");
        }

        public void AddHttpService<T>(string path) where T : FuyuBehaviour, new()
        {
            var behaviour = new T();
            if (behaviour is DynamicFuyuBehaviour dynamicBehaviour)
            {
                ProcessDynamicBehaviour(dynamicBehaviour, path);
                DynamicBehaviours.Add(dynamicBehaviour);
            }
            else
            {
                Behaviours.Add(path, behaviour);
            }
        }

        private void ProcessDynamicBehaviour(DynamicFuyuBehaviour dynamicBehaviour, string path)
        {
            var pathSegments = dynamicBehaviour.PathSegments = path.Split('/');
            var dynamicSegments = dynamicBehaviour.DynamicSegments = new List<DynamicPathSegment>();

            for (int i = 0; i < pathSegments.Length; i++)
            {
                var segment = pathSegments[i];
                if (segment.StartsWith("{") && segment.EndsWith("}"))
                {
                    var pathName = segment.Trim('{', '}');
                    dynamicSegments.Add(new DynamicPathSegment(pathName, i));
                }
            }

            if (dynamicSegments.Count == 0)
            {
                throw new ArgumentException("Registered DynamicFuyuBehaviour but path is not dynamic", nameof(path));
            }
        }
    }
}