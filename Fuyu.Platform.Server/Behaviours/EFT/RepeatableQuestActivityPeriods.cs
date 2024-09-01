using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Networking;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class RepeatableQuestActivityPeriods : HttpBehaviour
    {
        public RepeatableQuestActivityPeriods() : base("/client/repeatalbeQuests/activityPeriods")
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