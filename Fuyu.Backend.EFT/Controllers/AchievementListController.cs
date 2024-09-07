using Fuyu.Common.Networking;

namespace Fuyu.Backend.EFT.Controllers
{
    public class AchievementListController : HttpController
    {
        public AchievementListController() : base("/client/achievement/list")
        {
        }

        public override void Run(HttpContext context)
        {
            SendJson(context, EftOrm.GetAchievementList());
        }
    }
}