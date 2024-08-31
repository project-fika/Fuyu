using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.IO;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class Globals : FuyuBehaviour
    {
        private readonly string _response;

        public Globals() : base("/client/globals")
        {
            _response = Resx.GetText("eft", "database.eft.client.globals.json");
        }

        public override void Run(FuyuContext context)
        {
            SendJson(context, _response);
        }
    }
}