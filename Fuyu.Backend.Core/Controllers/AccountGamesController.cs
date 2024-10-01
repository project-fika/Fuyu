using System.Threading.Tasks;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Backend.Core.DTO.Responses;
using Fuyu.Backend.Core.Services;

namespace Fuyu.Backend.Core.Controllers
{
    public class AccountGamesController : HttpController
    {
        public AccountGamesController() : base("/account/games")
        {
        }

        public override async Task RunAsync(HttpContext context)
        {
            var sessionId = context.GetSessionId();
            var result = AccountService.GetGames(sessionId);
            var response = new AccountGamesResponse()
            {
                Games = result
            };

            await context.SendJsonAsync(Json.Stringify(response));
        }
    }
}
