using System.Collections.Generic;
using System.Net;

namespace Fuyu.Common.Networking
{
    public class WebRouterContext : IRouterContext
    {
        protected readonly HttpListenerRequest Request;
        protected readonly HttpListenerResponse Response;
        public readonly string Path;

        public WebRouterContext(HttpListenerRequest request, HttpListenerResponse response)
        {
            Request = request;
            Response = response;
            Path = GetPath();
        }

        private string GetPath()
        {
            var path = Request.Url.PathAndQuery;

            if (path.Contains("?"))
            {
                path = path.Split('?')[0];
            }

            return path;
		}

		public Dictionary<string, string> GetPathParameters(IRoutable routable)
		{
			var result = new Dictionary<string, string>();
			var segments = Path.Split('/');
			var i = 0;

			foreach (var kvp in routable.Path)
			{
				if (kvp.Value == EPathSegment.Dynamic)
				{
					result.Add(kvp.Key, segments[i]);
				}

				++i;
			}

			return result;
		}
	}
}