using Fuyu.Server.Arena.DTO.Responses;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;

namespace Fuyu.Server.Arena.Controllers
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