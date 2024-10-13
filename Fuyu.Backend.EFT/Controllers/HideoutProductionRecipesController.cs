using System.Threading.Tasks;
using Fuyu.Common.Networking;

namespace Fuyu.Backend.EFT.Controllers
{
    public class HideoutProductionRecipesController : HttpController
    {
        public HideoutProductionRecipesController() : base("/client/hideout/production/recipes")
        {
        }

        public override async Task RunAsync(HttpContext context)
        {
            await context.SendJsonAsync(EftOrm.GetHideoutProductionRecipes());
        }
    }
}