using Fuyu.Common.Networking;

namespace Fuyu.Backend.EFT.Controllers
{
    public class ItemsController : HttpController
    {
        public ItemsController() : base("/client/items")
        {
        }

        public override void Run(HttpContext context)
        {
            SendJson(context, EftOrm.GetItems());
        }
    }
}