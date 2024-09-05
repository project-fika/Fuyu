using Fuyu.Common.IO;
using Fuyu.Common.Networking;

namespace Fuyu.Backend.EFT.Controllers
{
    public class HideoutAreasController : HttpController
    {
        private readonly string _response;

        public HideoutAreasController() : base("/client/hideout/areas")
        {
            _response = Resx.GetText("eft", "database.client.hideout.areas.json");
        }

        public override void Run(HttpContext context)
        {
            SendJson(context, _response);
        }
    }
}