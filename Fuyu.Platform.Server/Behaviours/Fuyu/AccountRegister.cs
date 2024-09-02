using Fuyu.Platform.Common.Models.Fuyu.Requests;
using Fuyu.Platform.Common.Models.Fuyu.Responses;
using Fuyu.Platform.Common.Networking;
using Fuyu.Platform.Common.Serialization;
using Fuyu.Platform.Server.Services.Fuyu;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class AccountRegister : HttpBehaviour
    {
        public AccountRegister() : base("/account/register")
        {
        }

        public override void Run(HttpContext context)
        {
            var request = context.GetJson<AccountRegisterRequest>();
            var result = AccountService.RegisterAccount(request.Username, request.Password, request.Edition);
            var response = new AccountRegisterResponse()
            {
                Status = result
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}