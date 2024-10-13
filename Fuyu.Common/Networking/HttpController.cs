using System.Text.RegularExpressions;

namespace Fuyu.Common.Networking
{
	public abstract class HttpController : WebController<HttpContext>
	{
		protected HttpController(Regex pattern) : base(pattern)
		{
		}

		protected HttpController(string path) : base(path)
		{
		}
	}
}