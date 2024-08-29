using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Serialization;
using Fuyu.Platform.Server.Databases;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class GameProfileNicknameReserved : FuyuBehaviour
    {
        public override void Run(FuyuContext context)
        {
            var sessionId = context.GetSessionId();
            var accountId = FuyuDatabase.Accounts.GetSession(sessionId);
            var account = FuyuDatabase.Accounts.GetAccount(accountId);

            var response = new ResponseBody<string>()
            {
                data = account.Username
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}