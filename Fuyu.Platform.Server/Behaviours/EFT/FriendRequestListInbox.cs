using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class FriendRequestListInbox : FuyuHttpBehaviour
    {
        public FriendRequestListInbox() : base("/client/friend/request/list/inbox")
        {
        }

        public override void Run(FuyuHttpContext context)
        {
            var response = new ResponseBody<object[]>()
            {
                data = []
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}