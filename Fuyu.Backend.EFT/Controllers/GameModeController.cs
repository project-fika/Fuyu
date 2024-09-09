using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Backend.BSG.DTO.Responses;
using Fuyu.Backend.EFT.DTO.Responses;

namespace Fuyu.Backend.EFT.Controllers
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

            context.SendJson(Json.Stringify(response));
        }
    }
}