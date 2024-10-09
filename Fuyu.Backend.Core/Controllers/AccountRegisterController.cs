using System.Threading.Tasks;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Backend.Core.DTO.Requests;
using Fuyu.Backend.Core.DTO.Responses;
using Fuyu.Backend.Core.Services;

namespace Fuyu.Backend.Core.Controllers
{
    public class AccountRegisterController : HttpController<AccountRegisterRequest>
    {
        public AccountRegisterController() : base("/account/register")
        {
        }

        public override Task RunAsync(HttpContext context, AccountRegisterRequest request)
        {
            var result = AccountService.RegisterAccount(request.Username, request.Password);
            var response = new AccountRegisterResponse()
            {
                Status = result
            };

            return context.SendJsonAsync(Json.Stringify(response));
        }
    }
}