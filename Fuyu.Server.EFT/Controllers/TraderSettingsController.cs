using Fuyu.Common.IO;
using Fuyu.Common.Networking;

namespace Fuyu.Server.EFT.Controllers
{
    public class TraderSettingsController : HttpController
    {
        private readonly string _response;

        public TraderSettingsController() : base("/client/trading/api/traderSettings")
        {
            _response = Resx.GetText("eft", "database.client.trading.api.traderSettings.json");
        }

        public override void Run(HttpContext context)
        {
            SendJson(context, _response);
        }
    }
}