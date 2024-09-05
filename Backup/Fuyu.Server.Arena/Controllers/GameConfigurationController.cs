using Fuyu.Backend.Arena.DTO.Responses;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;

namespace Fuyu.Backend.Arena.Controllers
{
    public class GameConfigurationController : HttpController
    {
        public GameConfigurationController() : base("/client/game/configuration")
        {
        }

        public override void Run(HttpContext context)
        {
            var response = new ResponseBody<GameConfigResponse>
            {
                data = new GameConfigResponse()
                {
                    backend = new Backends()
                    {
                        Main        = "http://localhost:8020",
                        Lobby       = "http://localhost:8020"
                    },
                    utc_time = 1725255838.3959,
                    reportAvailable = true,
                    purchasedGames = new PurchasedGames()
                    {
                        eft = true,
                        arena = true
                    },
                    isGameSynced = true
                }
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}