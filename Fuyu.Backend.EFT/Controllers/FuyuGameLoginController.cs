using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Backend.EFT.Services;
using Fuyu.Backend.Common.DTO.Requests;
using Fuyu.Backend.Common.DTO.Responses;

namespace Fuyu.Backend.EFT.Controllers
{
    public class FuyuGameLoginController : HttpController
    {
        public FuyuGameLoginController() : base("/fuyu/game/login")
        {
        }

        public override void Run(HttpContext context)
        {
            var request = context.GetJson<FuyuGameLoginRequest>();
            var sessionId = AccountService.LoginAccount(request.AccountId);
            var response = new FuyuGameLoginResponse()
            {
                SessionId = sessionId
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}