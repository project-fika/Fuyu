using Fuyu.Server.Arena.DTO.Responses;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;

namespace Fuyu.Server.Arena.Controllers
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