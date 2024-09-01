using Fuyu.Platform.Common.IO;
using Fuyu.Platform.Common.Networking;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class HideoutProductionRecipes : HttpBehaviour
    {
        private readonly string _response;

        public HideoutProductionRecipes() : base("/client/hideout/production/recipes")
        {
            _response = Resx.GetText("eft", "database.eft.client.hideout.production.recipes.json");
        }

        public override void Run(HttpContext context)
        {
            SendJson(context, _response);
        }
    }
}