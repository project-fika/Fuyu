using Fuyu.Platform.Common.IO;
using Fuyu.Platform.Common.Networking;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class AchievementList : HttpBehaviour
    {
        private readonly string _response;

        public AchievementList() : base("/client/achievement/list")
        {
            _response = Resx.GetText("eft", "database.eft.client.achievement.list.json");
        }

        public override void Run(HttpContext context)
        {
            SendJson(context, _response);
        }
    }
}