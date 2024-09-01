using Fuyu.Platform.Common.IO;
using Fuyu.Platform.Common.Networking;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class HideoutAreas : HttpBehaviour
    {
        private readonly string _response;

        public HideoutAreas() : base("/client/hideout/areas")
        {
            _response = Resx.GetText("eft", "database.eft.client.hideout.areas.json");
        }

        public override void Run(HttpContext context)
        {
            SendJson(context, _response);
        }
    }
}