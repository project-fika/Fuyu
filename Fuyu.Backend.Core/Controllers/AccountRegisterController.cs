using Fuyu.Backend.Core.DTO.Requests;
using Fuyu.Backend.Core.DTO.Responses;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Backend.Core.Services;

namespace Fuyu.Backend.Core.Controllers
{
    public class AccountRegisterController : HttpController
    {
        public AccountRegisterController() : base("/account/register")
        {
        }

        public override void Run(HttpContext context)
        {
            var request = context.GetJson<AccountRegisterRequest>();
            var result = AccountService.RegisterAccount(request.Username, request.Password);
            var response = new AccountRegisterResponse()
            {
                Status = result
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}