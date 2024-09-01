using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class MatchGroupCurrent : FuyuHttpBehaviour
    {
        public MatchGroupCurrent() : base("/client/match/group/current")
        {
        }

        public override void Run(FuyuHttpContext context)
        {
            var response = new ResponseBody<MatchGroupCurrentResponse>()
            {
                data = new MatchGroupCurrentResponse()
                {
                    squad = []
                }
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}