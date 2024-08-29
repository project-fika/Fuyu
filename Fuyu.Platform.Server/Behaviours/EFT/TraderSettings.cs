using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.IO;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class TraderSettings : FuyuBehaviour
    {
        private readonly string _response;

        public TraderSettings()
        {
            _response = Resx.GetText("eft", "database.eft.client.trading.api.traderSettings.json");
        }

        public override void Run(FuyuContext context)
        {
            SendJson(context, _response);
        }
    }
}