using Fuyu.Backend.Arena.DTO.Responses;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;

namespace Fuyu.Backend.Arena.Controllers
{
    public class FriendRequestListInboxController : HttpController
    {
        public FriendRequestListInboxController() : base("/client/friend/request/list/inbox")
        {
        }

        public override async Task RunAsync(HttpContext context)
        {
            var response = new ResponseBody<object[]>()
            {
                data = []
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}