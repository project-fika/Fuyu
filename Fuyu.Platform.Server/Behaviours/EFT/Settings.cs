using Fuyu.Platform.Common.IO;
using Fuyu.Platform.Common.Networking;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class Settings : HttpBehaviour
    {
        private readonly string _response;

        public Settings() : base("/client/settings")
        {
            _response = Resx.GetText("eft", "database.eft.client.settings.json");
        }

        public override void Run(HttpContext context)
        {
            SendJson(context, _response);
        }
    }
}