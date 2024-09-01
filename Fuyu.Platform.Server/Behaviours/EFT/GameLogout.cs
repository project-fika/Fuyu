using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Networking;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class GameLogout : HttpBehaviour
    {
        public GameLogout() : base("/client/game/logout")
        {
        }

        public override void Run(HttpContext context)
        {
            var response = new ResponseBody<GameLogoutResponse>()
            {
                data = new GameLogoutResponse()
                {
                    status = "ok"
                }
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}