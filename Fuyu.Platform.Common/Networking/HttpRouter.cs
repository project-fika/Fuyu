using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fuyu.Platform.Common.Networking
{
    public class HttpRouter
    {
        public readonly List<HttpBehaviour> Behaviours;

        public HttpRouter()
        {
            Behaviours = new List<HttpBehaviour>();
        }

        public void Route(HttpContext context)
        {
            // NOTE: multi-threaded lookup
            var matches = new ConcurrentBag<HttpBehaviour>();

            Parallel.ForEach(Behaviours, (behaviour) =>
            {
                if (behaviour.IsMatch(context))
                {
                    matches.Add(behaviour);
                }
            });

            if (matches.Count == 0)
            {
                throw new Exception($"No match on path {context.Path}");
            }

            // NOTE: do we want to support multi-matching?
            if (matches.Count > 1)
            {
                throw new Exception($"Too many matches on path {context.Path}");
            }

            foreach (var match in matches)
            {
                match.Run(context);
            }
        }

        public void AddService<T>() where T : HttpBehaviour, new()
        {
            Behaviours.Add(new T());
        }
    }
}