using Fuyu.Platform.Common.Models.Fuyu.Requests;
using Fuyu.Platform.Common.Models.Fuyu.Responses;
using Fuyu.Platform.Common.Networking;
using Fuyu.Platform.Common.Serialization;
using Fuyu.Platform.Server.Services.Fuyu;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class AccountLogin : HttpBehaviour
    {
        public AccountLogin() : base("/account/login")
        {
        }

        public override void Run(HttpContext context)
        {
            var request = context.GetJson<AccountLoginRequest>();
            var result = AccountService.LoginAccount(request.Username, request.Password);
            var response = new AccountLoginResponse()
            {
                SessionId = result
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}