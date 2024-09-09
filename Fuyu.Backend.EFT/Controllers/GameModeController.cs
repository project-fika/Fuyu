using System.Threading.Tasks;
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

        public override async Task RunAsync(HttpContext context)
        {
            var response = new ResponseBody<GameModeResponse>()
            {
                data = new GameModeResponse()
                {
                    gameMode = "pve",
                    backendUrl = "http://localhost:8010"
                }
            };

            await context.SendJsonAsync(Json.Stringify(response));
        }
    }
}