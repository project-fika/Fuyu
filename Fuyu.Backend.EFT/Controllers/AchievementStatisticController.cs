using Fuyu.Common.IO;
using Fuyu.Backend.BSG.DTO.Responses;
using Fuyu.Backend.EFT.DTO.Responses;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;

namespace Fuyu.Backend.EFT.Controllers
{
    public class AchievementStatisticController : HttpController
    {
        public AchievementStatisticController() : base("/client/achievement/statistic")
        {
        }

        public override void Run(HttpContext context)
        {
            var json = EftOrm.GetAchievementStatistic();
            var response = Json.Parse<ResponseBody<AchievementStatisticResponse>>(json);
            SendJson(context, Json.Stringify(response));
        }
    }
}