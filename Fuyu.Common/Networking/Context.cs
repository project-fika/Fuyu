using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Fuyu.Common.Compression;
using Fuyu.Common.Serialization;

namespace Fuyu.Common.Networking
{
    public class Context
    {
        public readonly HttpListenerRequest Request;
        public readonly HttpListenerResponse Response;
        public readonly string Path;

        public Context(HttpListenerRequest request, HttpListenerResponse response)
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

        public Dictionary<string, string> GetPathParameters(HttpController behaviour)
        {
            var result = new Dictionary<string, string>();
            var segments = Path.Split('/');
            var i = 0;

            foreach (var kvp in behaviour.Path)
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