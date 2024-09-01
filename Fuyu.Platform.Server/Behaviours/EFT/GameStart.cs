using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Networking;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class GameStart : HttpBehaviour
    {
        public GameStart() : base("/client/game/start")
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