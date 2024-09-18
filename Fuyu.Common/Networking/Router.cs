using System;
using System.Collections.Generic;

namespace Fuyu.Common.Networking
{
    public class Router<T> where T : Controller
    {
        public readonly List<T> Controllers;

        public Router()
        {
            Controllers = new List<T>();
        }

        public List<T> GetAllMatching(Context context)
        {
            var matches = new List<T>();

            foreach (var controller in Controllers)
            {
                if (controller.IsMatch(context))
                {
                    matches.Add(controller);
                }
            }

            if (matches.Count == 0)
            {
                throw new RouteNotFoundException($"No match on path {context.Path}");
            }

            // NOTE: do we want to support multi-matching?
            // -- seionmoya, 2024/09/02
            if (matches.Count > 1)
            {
                throw new Exception($"Too many matches on path {context.Path}");
            }

            return matches;
        }
    }
}