using System.Threading.Tasks;
using Fuyu.Common.Networking;

namespace Fuyu.Backend.EFT.Controllers
{
    public class AchievementListController : HttpController
    {
        public AchievementListController() : base("/client/achievement/list")
        {
        }

        public override async Task RunAsync(HttpContext context)
        {
            await context.SendJsonAsync(EftOrm.GetAchievementList());
        }
    }
}