using System.Threading.Tasks;
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

        public override async Task RunAsync(HttpContext context)
        {
            var request = await context.GetJsonAsync<FuyuGameRegisterRequest>();
            var accountId = AccountService.RegisterAccount(request.Username, request.Edition);
            var response = new FuyuGameRegisterResponse()
            {
                AccountId = accountId
            };

            await context.SendJsonAsync(Json.Stringify(response));
        }
    }
}