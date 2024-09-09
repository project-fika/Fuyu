using Fuyu.Common.Networking;

namespace Fuyu.Backend.EFT.Controllers
{
    public class GlobalsController : HttpController
    {
        public GlobalsController() : base("/client/globals")
        {
        }

        public override void Run(HttpContext context)
        {
            context.SendJson(EftOrm.GetGlobals());
        }
    }
}