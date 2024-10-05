using System.Threading.Tasks;

namespace Fuyu.Common.Networking
{
    public class WsRouter : Router<WsController, WsContext>
    {
        public WsRouter() : base()
        {
        }

        public override async Task RouteAsync(WsContext context)
        {
            var matches = GetAllMatching(context);
            foreach (var match in matches)
            {
                await match.InitializeAsync(context);
                await match.RunAsync(context);
            }
        }
    }
}