using Fuyu.Platform.Common.Networking;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class GameMode : FuyuHttpBehaviour
    {
        public GameMode() : base("/client/game/mode")
        {
        }

        public override void Run(FuyuHttpContext context)
        {
            var response = new ResponseBody<GameModeResponse>()
            {
                data = new GameModeResponse()
                {
                    gameMode = "pve",
                    backendUrl = "http://localhost:8000"
                }
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}