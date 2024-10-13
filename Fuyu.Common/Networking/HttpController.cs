using System;
using System.Threading.Tasks;

namespace Fuyu.Common.Networking
{
    public abstract class HttpController : WebController<HttpContext>
    {
        public HttpController(string path) : base(path)
        {
        }
    }

	public abstract class HttpController<TRequest> : HttpController where TRequest : class
	{
		public HttpController(string path) : base(path)
		{
		}

		public override async Task RunAsync(HttpContext context)
		{
            // TODO:
            // - Use better exception type
            // -- seionmoya, 2024-10-13
            if (!context.HasBody())
            {
                throw new Exception("Request does not contain body.");
            }

            var body = await context.GetJsonAsync<TRequest>();

            // TODO:
            // - Use better exception type
            // -- seionmoya, 2024-10-13
            if (body == null)
            {
                throw new Exception("Body could not be parsed as TRequest.");
            }

			await RunAsync(context, body);
		}

		public abstract Task RunAsync(HttpContext context, TRequest body);
	}
}
