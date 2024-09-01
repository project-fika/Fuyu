using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class GameKeepalive : FuyuBehaviour
    {
        public GameKeepalive() : base("/client/game/keepalive")
        {
        }

        public override void Run(FuyuHttpContext context)
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