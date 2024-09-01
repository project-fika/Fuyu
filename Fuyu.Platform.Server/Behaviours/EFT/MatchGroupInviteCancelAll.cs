using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Networking;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class MatchGroupInviteCancelAll : HttpBehaviour
    {
        public MatchGroupInviteCancelAll() : base("/client/match/group/invite/cancel-all")
        {
        }

        public override void Run(HttpContext context)
        {
            var response = new ResponseBody<bool>()
            {
                data = true
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}