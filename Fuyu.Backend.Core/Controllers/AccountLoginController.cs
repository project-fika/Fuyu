using System.Threading.Tasks;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Backend.Core.DTO.Requests;
using Fuyu.Backend.Core.Services;

namespace Fuyu.Backend.Core.Controllers
{
    public class AccountLoginController : HttpController
    {
        public AccountLoginController() : base("/account/login")
        {
        }

		public override async Task RunAsync(HttpContext context)
		{
			var request = await context.GetJsonAsync<AccountLoginRequest>();
			var response = AccountService.LoginAccount(request.Username, request.Password);

			await context.SendJsonAsync(Json.Stringify(response));
		}
	}
}