using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Backend.BSG.DTO.Responses;
using Fuyu.Backend.EFT.DTO.Responses;

namespace Fuyu.Backend.EFT.Controllers
{
    public class GameLogoutController : HttpController
    {
        public GameLogoutController() : base("/client/game/logout")
        {
        }

        public override void Run(HttpContext context)
        {
            var response = new ResponseBody<GameLogoutResponse>()
            {
                data = new GameLogoutResponse()
                {
                    status = "ok"
                }
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}