using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.IO;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Server.Behaviours
{
    public class AchievementStatistic : FuyuBehaviour
    {
        private readonly ResponseBody<AchievementStatisticResponse> _response;

        public AchievementStatistic()
        {
            var json = Resx.GetText("fuyu", "database.client.achievement.statistic.json");
            _response = Json.Parse<ResponseBody<AchievementStatisticResponse>>(json);
        }

        public override void Run(FuyuContext context)
        {
            SendJson(context, Json.Stringify(_response));
        }
    }
}