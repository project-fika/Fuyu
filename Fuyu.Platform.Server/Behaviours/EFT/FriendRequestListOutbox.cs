using Fuyu.Platform.Common.Networking;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class FriendRequestListOutbox : FuyuHttpBehaviour
    {
        public FriendRequestListOutbox() : base("/client/friend/request/list/outbox")
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