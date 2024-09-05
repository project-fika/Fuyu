using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Backend.BSG.DTO.Responses;
using Fuyu.Backend.EFT.DTO.Responses;

namespace Fuyu.Backend.EFT.Controllers
{
    public class FriendListController : HttpController
    {
        public FriendListController() : base("/client/friend/list")
        {
        }

        public override void Run(HttpContext context)
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