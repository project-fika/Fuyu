using Fuyu.Common.IO;
using Fuyu.Common.Networking;

namespace Fuyu.Backend.EFT.Controllers
{
    public class ItemsController : HttpController
    {
        private readonly string _response;

        public ItemsController() : base("/client/items")
        {
            _response = Resx.GetText("eft", "database.client.items.json");
        }

        public override void Run(HttpContext context)
        {
            SendJson(context, _response);
        }
    }
}