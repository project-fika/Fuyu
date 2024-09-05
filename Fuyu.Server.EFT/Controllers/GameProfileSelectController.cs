using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Server.BSG.DTO.Responses;
using Fuyu.Server.EFT.DTO.Responses;

namespace Fuyu.Server.EFT.Controllers
{
    public class GameProfileSelectController : HttpController
    {
        public GameProfileSelectController() : base("/client/game/profile/select")
        {
        }

        public override void Run(HttpContext context)
        {
            var response = new ResponseBody<ProfileSelectResponse>()
            {
                data = new ProfileSelectResponse()
                {
                    status = "ok"
                }
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}