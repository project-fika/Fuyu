using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Fuyu.Common.Networking
{
	public abstract class WebController<TContext> : IRoutable, IRouterController<TContext> where TContext : WebRouterContext
    {
		public Regex Matcher { get; }

        public WebController(string pattern)
        {
			Matcher = new Regex(pattern);
        }

		public bool IsMatch(TContext context)
		{
			return Matcher.IsMatch(context.Path);
		}

		public abstract Task RunAsync(TContext context);
	}
}