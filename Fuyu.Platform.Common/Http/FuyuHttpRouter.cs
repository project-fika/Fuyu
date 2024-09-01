using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fuyu.Platform.Common.Http
{
    public class FuyuHttpRouter
    {
        public readonly List<FuyuBehaviour> Behaviours;

        public FuyuHttpRouter()
        {
            Behaviours = new List<FuyuBehaviour>();
        }

        public void Route(FuyuContext context)
        {
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

        public void AddService<T>() where T : FuyuBehaviour, new()
        {
            Behaviours.Add(new T());
        }
    }
}