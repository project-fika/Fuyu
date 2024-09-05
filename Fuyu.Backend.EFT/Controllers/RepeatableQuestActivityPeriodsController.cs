using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Backend.BSG.DTO.Responses;

namespace Fuyu.Backend.EFT.Controllers
{
    public class RepeatableQuestActivityPeriodsController : HttpController
    {
        public RepeatableQuestActivityPeriodsController() : base("/client/repeatalbeQuests/activityPeriods")
        {
        }

        public override void Run(HttpContext context)
        {
            var response = new ResponseBody<object[]>
            {
                data = []
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}