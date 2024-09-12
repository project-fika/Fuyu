using System.Threading.Tasks;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Backend.BSG.DTO.Responses;
using Fuyu.Backend.EFT.DTO.Responses;

namespace Fuyu.Backend.EFT.Controllers
{
    public class GameKeepaliveController : HttpController
    {
        public GameKeepaliveController() : base("/client/game/keepalive")
        {
        }

        public override async Task RunAsync(HttpContext context)
        {
            var response = new ResponseBody<GameKeepaliveResponse>
            {
                data = new GameKeepaliveResponse()
                {
                    msg = "OK",
                    utc_time = 1724627853.791631
                }
            };

            await context.SendJsonAsync(Json.Stringify(response));
        }
    }
}