namespace Fuyu.Common.Networking
{
	// Tag to prevent misuse of the router, such as Router<TController, int>
	// Routers should have strongly typed contexts
	public interface IRouterContext
	{
	}
}
