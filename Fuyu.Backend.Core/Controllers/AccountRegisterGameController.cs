using System.Threading.Tasks;
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

        public override async Task RunAsync(HttpContext context)
        {
            var request = await context.GetJsonAsync<AccountRegisterGameRequest>();
            var sessionId = context.GetSessionId();
            var result = AccountService.RegisterGame(sessionId, request.Game, request.Edition);
            var response = new AccountRegisterGameResponse()
            {
                Status = result
            };

            await context.SendJsonAsync(Json.Stringify(response));
        }
    }
}