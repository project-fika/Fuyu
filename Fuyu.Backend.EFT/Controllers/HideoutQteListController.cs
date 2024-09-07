using Fuyu.Common.Networking;

namespace Fuyu.Backend.EFT.Controllers
{
    public class HideoutQteListController : HttpController
    {
        public HideoutQteListController() : base("/client/hideout/qte/list")
        {
        }

        public override void Run(HttpContext context)
        {
            SendJson(context, EftOrm.GetHideoutQteList());
        }
    }
}