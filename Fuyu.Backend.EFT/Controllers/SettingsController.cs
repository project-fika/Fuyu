using Fuyu.Common.Networking;

namespace Fuyu.Backend.EFT.Controllers
{
    public class SettingsController : HttpController
    {
        public SettingsController() : base("/client/settings")
        {
        }

        public override void Run(HttpContext context)
        {
            SendJson(context, EftOrm.GetSettings());
        }
    }
}