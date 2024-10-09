using System.Threading.Tasks;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Backend.Core.DTO.Requests;
using Fuyu.Backend.Core.Services;

namespace Fuyu.Backend.Core.Controllers
{
    public class AccountRegisterGameController : HttpController<AccountRegisterGameRequest>
	{
        public AccountRegisterGameController() : base("/account/register/game")
        {
        }

        public override Task RunAsync(HttpContext context, AccountRegisterGameRequest request)
        {
            var sessionId = context.GetSessionId();
            var result = AccountService.RegisterGame(sessionId, request.Game, request.Edition);

            return context.SendJsonAsync(Json.Stringify(result));
        }
    }
}