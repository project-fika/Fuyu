using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fuyu.Common.Networking
{
    public class HttpRouter : Router<HttpController>
    {
        public HttpRouter() : base()
        {
        }

        public async Task RouteAsync(HttpContext context)
        {
            var matches = GetAllMatching(context);

            foreach (var match in matches)
            {
                await Task.Run(() => match.RunAsync(context));
            }
        }
    }
}