using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class MatchGroupInviteCancelAll : FuyuHttpBehaviour
    {
        public MatchGroupInviteCancelAll() : base("/client/match/group/invite/cancel-all")
        {
        }

        public override void Run(FuyuHttpContext context)
        {
            var response = new ResponseBody<bool>()
            {
                data = true
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}