using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Server.BSG.DTO.Responses;
using Fuyu.Server.EFT.DTO.Responses;

namespace Fuyu.Server.EFT.Controllers
{
    public class GameModeController : HttpController
    {
        public GameModeController() : base("/client/game/mode")
        {
        }

        public override void Run(HttpContext context)
        {
            var response = new ResponseBody<GameModeResponse>()
            {
                data = new GameModeResponse()
                {
                    gameMode = "pve",
                    backendUrl = "http://localhost:8010"
                }
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}