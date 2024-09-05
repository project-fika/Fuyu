using Fuyu.Backend.Arena.DTO.Responses;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;

namespace Fuyu.Backend.Arena.Controllers
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
                    utc_time = 1725255838.0694
                }
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}