using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Networking;
using Fuyu.Platform.Common.Serialization;
using Fuyu.Platform.Server.Databases;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class GameProfileNicknameReserved : HttpBehaviour
    {
        public GameProfileNicknameReserved() : base("/client/game/profile/nickname/reserved")
        {
        }

        public override void Run(HttpContext context)
        {
            var sessionId = context.GetSessionId();
            var account = FuyuDatabase.Accounts.GetAccount(sessionId);

            var response = new ResponseBody<string>()
            {
                data = account.Username
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}