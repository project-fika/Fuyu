using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Server.BSG.DTO.Responses;

namespace Fuyu.Server.EFT.Controllers
{
    public class FriendRequestListInboxController : HttpController
    {
        public FriendRequestListInboxController() : base("/client/friend/request/list/inbox")
        {
        }

        public override void Run(HttpContext context)
        {
            var response = new ResponseBody<object[]>()
            {
                data = []
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}