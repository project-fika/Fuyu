using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Networking;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class GameKeepalive : HttpBehaviour
    {
        public GameKeepalive() : base("/client/game/keepalive")
        {
        }

        public override void Run(HttpContext context)
        {
            var response = new ResponseBody<GameKeepaliveResponse>
            {
                data = new GameKeepaliveResponse()
                {
                    msg = "OK",
                    utc_time = 1724627853.791631
                }
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}