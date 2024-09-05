using Fuyu.Common.IO;
using Fuyu.Common.Networking;

namespace Fuyu.Server.EFT.Controllers
{
    public class GlobalsController : HttpController
    {
        private readonly string _response;

        public GlobalsController() : base("/client/globals")
        {
            _response = Resx.GetText("eft", "database.client.globals.json");
        }

        public override void Run(HttpContext context)
        {
            SendJson(context, _response);
        }
    }
}