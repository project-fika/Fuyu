using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fuyu.Common.Networking
{
    public abstract class WebController<TContext> : IRouterController<TContext> where TContext : WebRouterContext
    {
        public readonly Dictionary<string, EPathSegment> Path;

        public WebController(string path)
        {
            Path = InitializePath(path);
        }

        private static Dictionary<string, EPathSegment> InitializePath(string path)
        {
            var result = new Dictionary<string, EPathSegment>();
            var segments = path.Split('/');

            foreach (var segment in segments)
            {
                if (segment.StartsWith("{") && segment.EndsWith("}"))
                {
                    var name = segment.Trim('{', '}');
                    result.Add(name, EPathSegment.Dynamic);
                }
                else
                {
                    result.Add(segment, EPathSegment.Static);
                }
            }

            return result;
        }

		public bool IsMatch(TContext context)
		{
			var segments = context.Path.Split('/');
			var i = 0;

			if (segments.Length != Path.Count)
			{
				// segment length does not match
				return false;
			}

			foreach (var kvp in Path)
			{
				// validate static segment
				if (kvp.Value == EPathSegment.Static && segments[i] != kvp.Key)
				{
					return false;
				}

				++i;
			}

			return true;
		}

		public abstract Task RunAsync(TContext context);
	}
}