using System.Threading.Tasks;

namespace Fuyu.Common.Networking
{
    public abstract class HttpController : Controller
    {
        public HttpController(string path) : base(path)
        {
        }

        public abstract Task RunAsync(HttpContext context);
    }
}