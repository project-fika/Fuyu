using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fuyu.Common.Networking
{
    public class HttpRouter
    {
        public readonly List<HttpController> Controllers;

        public HttpRouter()
        {
            Controllers = new List<HttpController>();
        }

        public void Route(HttpContext context)
        {
            // NOTE: multi-threaded lookup
            var matches = new ConcurrentBag<HttpController>();

            Parallel.ForEach(Controllers, (controller) =>
            {
                if (controller.IsMatch(context))
                {
                    matches.Add(controller);
                }
            });

            if (matches.Count == 0)
            {
                throw new Exception($"No match on path {context.Path}");
            }

            // NOTE: do we want to support multi-matching?
            // -- seionmoya, 2024/09/02
            if (matches.Count > 1)
            {
                throw new Exception($"Too many matches on path {context.Path}");
            }

            foreach (var match in matches)
            {
                match.Run(context);
            }
        }
    }
}