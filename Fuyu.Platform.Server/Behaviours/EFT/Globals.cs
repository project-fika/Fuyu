using Fuyu.Platform.Common.Networking;
using Fuyu.Platform.Common.IO;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class Globals : FuyuHttpBehaviour
    {
        private readonly string _response;

        public Globals() : base("/client/globals")
        {
            _response = Resx.GetText("eft", "database.eft.client.globals.json");
        }

        public override void Run(FuyuHttpContext context)
        {
            SendJson(context, _response);
        }
    }
}