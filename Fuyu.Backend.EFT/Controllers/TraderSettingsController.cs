using Fuyu.Common.Networking;

namespace Fuyu.Backend.EFT.Controllers
{
    public class TraderSettingsController : HttpController
    {
        public TraderSettingsController() : base("/client/trading/api/traderSettings")
        {
        }

        public override void Run(HttpContext context)
        {
            context.SendJson(EftOrm.GetTraders());
        }
    }
}