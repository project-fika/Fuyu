using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.Models.EFT.Requests;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Serialization;
using Fuyu.Platform.Server.Databases;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class GameProfileNicknameValidate : FuyuBehaviour
    {
        public override void Run(FuyuContext context)
        {
            var request = context.GetJson<GameProfileNicknameValidateRequest>();
            var sessionId = context.GetSessionId();
            var accountId = FuyuDatabase.Accounts.GetSession(sessionId);
            var account = FuyuDatabase.Accounts.GetAccount(accountId);

            // TODO: validate nickname usage

            var response = new ResponseBody<GameProfileNicknameValidateResponse>()
            {
                data = new GameProfileNicknameValidateResponse()
                {
                    status = "ok"
                }
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}