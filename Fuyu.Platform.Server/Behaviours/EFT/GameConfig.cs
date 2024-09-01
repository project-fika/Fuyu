using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class GameConfig : FuyuHttpBehaviour
    {
        public GameConfig() : base("/client/game/config")
        {
        }

        public override void Run(FuyuHttpContext context)
        {
            var response = new ResponseBody<GameConfigResponse>
            {
                data = new GameConfigResponse()
                {
                    backend = new Backends()
                    {
                        Lobby       = "http://localhost:8000",
                        Trading     = "http://localhost:8000",
                        Messaging   = "http://localhost:8000",
                        Main        = "http://localhost:8000",
                        RagFair     = "http://localhost:8000"
                    },
                    utc_time = 1724450891.010541,
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