using System.Threading.Tasks;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Backend.Core.DTO.Requests;
using Fuyu.Backend.Core.Services;

namespace Fuyu.Backend.Core.Controllers
{
    public class AccountLoginController : HttpController<AccountLoginRequest>
    {
        public AccountLoginController() : base("/account/login")
        {
        }

		public override Task RunAsync(HttpContext context, AccountLoginRequest body)
		{
			var response = AccountService.LoginAccount(body.Username, body.Password);

			return context.SendJsonAsync(Json.Stringify(response));
		}
	}
}