using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.IO;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class HideoutProductionRecipes : FuyuBehaviour
    {
        private readonly string _response;

        public HideoutProductionRecipes() : base("/client/hideout/production/recipes")
        {
            _response = Resx.GetText("eft", "database.eft.client.hideout.production.recipes.json");
        }

        public override void Run(FuyuContext context)
        {
            SendJson(context, _response);
        }
    }
}