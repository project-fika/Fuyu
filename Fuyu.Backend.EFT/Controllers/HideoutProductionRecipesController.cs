using Fuyu.Common.IO;
using Fuyu.Common.Networking;

namespace Fuyu.Backend.EFT.Controllers
{
    public class HideoutProductionRecipesController : HttpController
    {
        private readonly string _response;

        public HideoutProductionRecipesController() : base("/client/hideout/production/recipes")
        {
            _response = Resx.GetText("eft", "database.client.hideout.production.recipes.json");
        }

        public override void Run(HttpContext context)
        {
            SendJson(context, _response);
        }
    }
}