using Fuyu.Backend.Core.DTO.Requests;
using Fuyu.Backend.Core.DTO.Responses;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Backend.Core.Services;

namespace Fuyu.Backend.Core.Controllers
{
    public class AccountRegisterGameController : HttpController
    {
        public AccountRegisterGameController() : base("/account/register/game")
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

            context.SendJson(Json.Stringify(response));
        }
    }
}