using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Server.BSG.DTO.Responses;

namespace Fuyu.Server.EFT.Controllers
{
    public class GameProfileNicknameReservedController : HttpController
    {
        public GameProfileNicknameReservedController() : base("/client/game/profile/nickname/reserved")
        {
        }

        public override void Run(HttpContext context)
        {
            var sessionId = context.GetSessionId();
            var account = EftOrm.GetAccount(sessionId);

            var response = new ResponseBody<string>()
            {
                data = account.Username
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}