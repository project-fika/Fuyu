using Fuyu.Common.IO;
using Fuyu.Common.Networking;

namespace Fuyu.Server.EFT.Controllers
{
    public class SettingsController : HttpController
    {
        private readonly string _response;

        public SettingsController() : base("/client/settings")
        {
            _response = Resx.GetText("eft", "database.client.settings.json");
        }

        public override void Run(HttpContext context)
        {
            SendJson(context, _response);
        }
    }
}