using System.Threading.Tasks;

namespace Fuyu.Common.Networking
{
	public abstract class BodyAwareHttpController<TRequest> : HttpController where TRequest: class
	{
		public BodyAwareHttpController(string path) : base(path)
		{
		}

		public override async Task RunAsync(HttpContext context)
		{
			TRequest body = null;

			// NOTE: I'm not sure exactly how we should handle this. I imagine we still want the endpoint to be called?
			// -- nexus4880, 2024-10-07
			if (context.HasBody())
			{
				body = await context.GetJsonAsync<TRequest>();
			}

			await RunAsync(context, body);
		}

		public abstract Task RunAsync(HttpContext context, TRequest body);
	}
}