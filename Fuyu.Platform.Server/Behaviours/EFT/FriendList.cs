using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class FriendList : FuyuBehaviour
    {
        public FriendList() : base("/client/friend/list")
        {
        }

        public override void Run(FuyuContext context)
        {
            var response = new ResponseBody<FriendListResponse>()
            {
                data = new FriendListResponse()
                {
                    Friends = [],
                    Ignore = [],
                    InIgnoreList = []
                }
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}