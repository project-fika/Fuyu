using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Backend.EFT.Services;
using Fuyu.Backend.Common.DTO.Requests;
using Fuyu.Backend.Common.DTO.Responses;

namespace Fuyu.Backend.EFT.Controllers
{
    public class FuyuGameRegisterController : HttpController
    {
        public FuyuGameRegisterController() : base("/fuyu/game/register")
        {
        }

        public override void Run(HttpContext context)
        {
            var request = context.GetJson<FuyuGameRegisterRequest>();
            var accountId = AccountService.RegisterAccount(request.Username, request.Edition);
            var response = new FuyuGameRegisterResponse()
            {
                AccountId = accountId
            };

            context.SendJson(Json.Stringify(response));
        }
    }
}