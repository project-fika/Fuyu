using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.IO;

namespace Fuyu.Platform.Server.Behaviours
{
    public class AchievementList : FuyuBehaviour
    {
        private readonly string _response;

        public AchievementList()
        {
            _response = Resx.GetText("fuyu", "database.client.achievement.list.json");
        }

        public override void Run(FuyuContext context)
        {
            SendJson(context, _response);
        }
    }
}