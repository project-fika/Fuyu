using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.IO;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class Settings : FuyuBehaviour
    {
        private readonly string _response;

        public Settings() : base("/client/settings")
        {
            _response = Resx.GetText("eft", "database.eft.client.settings.json");
        }

        public override void Run(FuyuContext context)
        {
            SendJson(context, _response);
        }
    }
}