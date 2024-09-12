using System.Threading.Tasks;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Backend.BSG.DTO.Responses;

namespace Fuyu.Backend.EFT.Controllers
{
    public class GameVersionValidateController : HttpController
    {
        public GameVersionValidateController() : base("/client/game/version/validate")
        {
        }

        public override async Task RunAsync(HttpContext context)
        {
            var response = new ResponseBody<object>()
            {
                data = null
            };

            await context.SendJsonAsync(Json.Stringify(response));
        }
    }
}