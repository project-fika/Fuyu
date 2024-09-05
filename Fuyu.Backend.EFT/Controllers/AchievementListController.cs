using Fuyu.Common.IO;
using Fuyu.Common.Networking;

namespace Fuyu.Backend.EFT.Controllers
{
    public class AchievementListController : HttpController
    {
        private readonly string _response;

        public AchievementListController() : base("/client/achievement/list")
        {
            _response = Resx.GetText("eft", "database.client.achievement.list.json");
        }

        public override void Run(HttpContext context)
        {
            SendJson(context, _response);
        }
    }
}