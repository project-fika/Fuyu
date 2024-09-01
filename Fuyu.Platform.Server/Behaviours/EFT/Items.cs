using Fuyu.Platform.Common.IO;
using Fuyu.Platform.Common.Networking;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class Items : HttpBehaviour
    {
        private readonly string _response;

        public Items() : base("/client/items")
        {
            _response = Resx.GetText("eft", "database.eft.client.items.json");
        }

        public override void Run(HttpContext context)
        {
            SendJson(context, _response);
        }
    }
}