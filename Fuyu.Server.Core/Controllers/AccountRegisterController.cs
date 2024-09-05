using Fuyu.Server.Core.DTO.Requests;
using Fuyu.Server.Core.DTO.Responses;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Server.Core.Services;

namespace Fuyu.Server.Core.Controllers
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