using Fuyu.Common.Networking;

namespace Fuyu.Backend.EFT.Controllers
{
    public class HideoutAreasController : HttpController
    {
        public HideoutAreasController() : base("/client/hideout/areas")
        {
        }

        public override void Run(HttpContext context)
        {
            SendJson(context, EftOrm.GetHideoutAreas());
        }
    }
}