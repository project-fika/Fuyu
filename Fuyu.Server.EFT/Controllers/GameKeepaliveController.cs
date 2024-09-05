using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Server.BSG.DTO.Responses;
using Fuyu.Server.EFT.DTO.Responses;

namespace Fuyu.Server.EFT.Controllers
{
    public class GameKeepaliveController : HttpController
    {
        public GameKeepaliveController() : base("/client/game/keepalive")
        {
        }

        public override void Run(HttpContext context)
        {
            var response = new ResponseBody<GameKeepaliveResponse>
            {
                data = new GameKeepaliveResponse()
                {
                    msg = "OK",
                    utc_time = 1724627853.791631
                }
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}