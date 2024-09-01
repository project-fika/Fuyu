using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.IO;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class HideoutAreas : FuyuBehaviour
    {
        private readonly string _response;

        public HideoutAreas() : base("/client/hideout/areas")
        {
            _response = Resx.GetText("eft", "database.eft.client.hideout.areas.json");
        }

        public override void Run(FuyuHttpContext context)
        {
            SendJson(context, _response);
        }
    }
}