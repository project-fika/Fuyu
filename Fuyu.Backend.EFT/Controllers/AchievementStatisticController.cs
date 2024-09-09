using System.Threading.Tasks;
using Fuyu.Common.IO;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Backend.BSG.DTO.Responses;
using Fuyu.Backend.EFT.DTO.Responses;

namespace Fuyu.Backend.EFT.Controllers
{
    public class AchievementStatisticController : HttpController
    {
        public AchievementStatisticController() : base("/client/achievement/statistic")
        {
        }

        public override async Task RunAsync(HttpContext context)
        {
            var json = EftOrm.GetAchievementStatistic();
            var response = Json.Parse<ResponseBody<AchievementStatisticResponse>>(json);
            await context.SendJsonAsync(Json.Stringify(response));
        }
    }
}