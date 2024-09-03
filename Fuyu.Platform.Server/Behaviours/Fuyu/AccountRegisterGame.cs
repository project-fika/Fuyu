using Fuyu.Platform.Common.Models.Fuyu.Requests;
using Fuyu.Platform.Common.Models.Fuyu.Responses;
using Fuyu.Platform.Common.Networking;
using Fuyu.Platform.Common.Serialization;
using Fuyu.Platform.Server.Services.Fuyu;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class AccountRegisterGame : HttpBehaviour
    {
        public AccountRegisterGame() : base("/account/register/game")
        {
        }

        public override void Run(HttpContext context)
        {
            var request = context.GetJson<AccountRegisterGameRequest>();
            var sessionId = context.GetSessionId();
            var result = AccountService.RegisterGame(sessionId, request.Game, request.Edition);
            var response = new AccountRegisterGameResponse()
            {
                Status = result
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}