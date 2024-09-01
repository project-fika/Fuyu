using Fuyu.Platform.Common.IO;
using Fuyu.Platform.Common.Networking;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class Globals : HttpBehaviour
    {
        private readonly string _response;

        public Globals() : base("/client/globals")
        {
            _response = Resx.GetText("eft", "database.eft.client.globals.json");
        }

        public override void Run(HttpContext context)
        {
            SendJson(context, _response);
        }
    }
}