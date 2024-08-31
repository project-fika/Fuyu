using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.IO;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class Items : FuyuBehaviour
    {
        private readonly string _response;

        public Items() : base("/client/items")
        {
            _response = Resx.GetText("eft", "database.eft.client.items.json");
        }

        public override void Run(FuyuContext context)
        {
            SendJson(context, _response);
        }
    }
}