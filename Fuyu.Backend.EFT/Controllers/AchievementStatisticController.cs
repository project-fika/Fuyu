using Fuyu.Common.IO;
using Fuyu.Backend.BSG.DTO.Responses;
using Fuyu.Backend.EFT.DTO.Responses;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;

namespace Fuyu.Backend.EFT.Controllers
{
    public class AchievementStatisticController : HttpController
    {
        private readonly ResponseBody<AchievementStatisticResponse> _response;

        public AchievementStatisticController() : base("/client/achievement/statistic")
        {
            var json = Resx.GetText("eft", "database.client.achievement.statistic.json");
            _response = Json.Parse<ResponseBody<AchievementStatisticResponse>>(json);
        }

        public override void Run(HttpContext context)
        {
            SendJson(context, Json.Stringify(_response));
        }
    }
}