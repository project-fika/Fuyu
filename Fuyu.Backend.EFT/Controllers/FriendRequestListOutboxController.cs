using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Backend.BSG.DTO.Responses;

namespace Fuyu.Backend.EFT.Controllers
{
    public class FriendRequestListOutboxController : HttpController
    {
        public FriendRequestListOutboxController() : base("/client/friend/request/list/outbox")
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