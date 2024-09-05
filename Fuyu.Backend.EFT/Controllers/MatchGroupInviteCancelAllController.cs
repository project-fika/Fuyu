using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Backend.BSG.DTO.Responses;

namespace Fuyu.Backend.EFT.Controllers
{
    public class MatchGroupInviteCancelAllController : HttpController
    {
        public MatchGroupInviteCancelAllController() : base("/client/match/group/invite/cancel-all")
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