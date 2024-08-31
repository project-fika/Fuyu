using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.IO;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class AchievementList : FuyuBehaviour
    {
        private readonly string _response;

        public AchievementList() : base("/client/achievement/list")
        {
            _response = Resx.GetText("eft", "database.eft.client.achievement.list.json");
        }

        public override void Run(FuyuContext context)
        {
            SendJson(context, _response);
        }
    }
}