using System.Collections.Generic;
using System.Net;

namespace Fuyu.Common.Networking
{
    public class WebRouterContext : IRouterContext
    {
        protected readonly HttpListenerRequest Request;
        protected readonly HttpListenerResponse Response;
        public string Path { get; }

        public WebRouterContext(HttpListenerRequest request, HttpListenerResponse response)
        {
            Request = request;
            Response = response;
            Path = Request.Url.AbsolutePath;
        }

		public Dictionary<string, string> GetPathParameters(IRoutable routable)
		{
			var result = new Dictionary<string, string>();
			var match = routable.Matcher.Match(Path);

			if (match.Success)
			{
				var names = routable.Matcher.GetGroupNames();

                // NOTE: index 0 is always "0"
                // -- nexus4880, 2024-10-11
				for (int i = 1; i < names.Length; i++)
				{
                    var groupName = names[i];
					result[groupName] = match.Groups[groupName].Value;
				}
			}

			return result;
		}
	}
}