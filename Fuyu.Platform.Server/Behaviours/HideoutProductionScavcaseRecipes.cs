using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.IO;

namespace Fuyu.Platform.Server.Behaviours
{
    public class HideoutProductionScavcaseRecipes : FuyuBehaviour
    {
        private readonly string _response;

        public HideoutProductionScavcaseRecipes()
        {
            _response = Resx.GetText("fuyu", "database.client.hideout.production.scavcase.recipes.json");
        }

        public override void Run(FuyuContext context)
        {
            SendJson(context, _response);
        }
    }
}