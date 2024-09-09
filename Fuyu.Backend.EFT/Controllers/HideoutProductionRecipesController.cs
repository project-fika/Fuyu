using Fuyu.Common.Networking;

namespace Fuyu.Backend.EFT.Controllers
{
    public class HideoutProductionRecipesController : HttpController
    {
        public HideoutProductionRecipesController() : base("/client/hideout/production/recipes")
        {
        }

        public override void Run(HttpContext context)
        {
            context.SendJson(EftOrm.GetHideoutProductionRecipes());
        }
    }
}