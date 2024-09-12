using System.Threading.Tasks;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Backend.BSG.DTO.Responses;

namespace Fuyu.Backend.EFT.Controllers
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

            await context.SendJsonAsync(Json.Stringify(response));
        }
    }
}