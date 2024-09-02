using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Networking;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class GameMode : HttpBehaviour
    {
        public GameMode() : base("/client/game/mode")
        {
        }

        public override void Run(HttpContext context)
        {
            var response = new ResponseBody<GameModeResponse>()
            {
                data = new GameModeResponse()
                {
                    gameMode = "pve",
                    backendUrl = "http://localhost:8001"
                }
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}