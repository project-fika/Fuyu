namespace Fuyu.Common.Networking
{
    public abstract class HttpController : Controller
    {
        public HttpController(string path) : base(path)
        {
        }

        public abstract void Run(HttpContext context);
    }
}