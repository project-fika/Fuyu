using Fuyu.Platform.Common.IO;
using Fuyu.Platform.Common.Networking;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class TraderSettings : HttpBehaviour
    {
        private readonly string _response;

        public TraderSettings() : base("/client/trading/api/traderSettings")
        {
            _response = Resx.GetText("eft", "database.eft.client.trading.api.traderSettings.json");
        }

        public override void Run(HttpContext context)
        {
            SendJson(context, _response);
        }
    }
}