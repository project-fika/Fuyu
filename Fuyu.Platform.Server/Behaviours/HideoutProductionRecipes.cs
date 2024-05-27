using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.IO;

namespace Fuyu.Platform.Server.Behaviours
{
    public class HideoutProductionRecipes : FuyuBehaviour
    {
        private readonly string _response;

        public HideoutProductionRecipes()
        {
            _response = Resx.GetText("fuyu", "database.client.hideout.production.recipes.json");
        }

        public override void Run(FuyuContext context)
        {
            SendJson(context, _response);
        }
    }
}