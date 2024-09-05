using Fuyu.Common.IO;
using Fuyu.Common.Networking;

namespace Fuyu.Server.EFT.Controllers
{
    public class HideoutQteListController : HttpController
    {
        private readonly string _response;

        public HideoutQteListController() : base("/client/hideout/qte/list")
        {
            _response = Resx.GetText("eft", "database.client.hideout.qte.list.json");
        }

        public override void Run(HttpContext context)
        {
            SendJson(context, _response);
        }
    }
}