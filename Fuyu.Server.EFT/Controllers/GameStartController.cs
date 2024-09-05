using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Server.BSG.DTO.Responses;
using Fuyu.Server.EFT.DTO.Responses;

namespace Fuyu.Server.EFT.Controllers
{
    public class GameStartController : HttpController
    {
        public GameStartController() : base("/client/game/start")
        {
        }

        public override void Run(HttpContext context)
        {
            var response = new ResponseBody<GameStartResponse>()
            {
                data = new GameStartResponse()
                {
                    utc_time = 1711579783.2164
                }
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}