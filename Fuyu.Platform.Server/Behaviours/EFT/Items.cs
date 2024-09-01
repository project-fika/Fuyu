using Fuyu.Platform.Common.Networking;
using Fuyu.Platform.Common.IO;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class Items : FuyuHttpBehaviour
    {
        private readonly string _response;

        public Items() : base("/client/items")
        {
            _response = Resx.GetText("eft", "database.eft.client.items.json");
        }

        public override void Run(FuyuHttpContext context)
        {
            SendJson(context, _response);
        }
    }
}