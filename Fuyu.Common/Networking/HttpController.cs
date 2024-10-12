namespace Fuyu.Common.Networking
{
    public abstract class HttpController : WebController<HttpContext>
    {
        public HttpController(string pattern) : base(pattern)
        {
        }
    }
}