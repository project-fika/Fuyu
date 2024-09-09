using System.Threading.Tasks;

namespace Fuyu.Common.Networking
{
    public abstract class WsController : Controller
    {
        public WsController(string path) : base(path)
        {
        }

        public abstract Task RunAsync(WsContext context);
    }
}