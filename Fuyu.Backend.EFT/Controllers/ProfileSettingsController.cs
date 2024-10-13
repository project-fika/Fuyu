using System.Threading.Tasks;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Backend.BSG.DTO.Responses;

namespace Fuyu.Backend.EFT.Controllers
{
    public class ProfileSettingsController : HttpController
    {
        public ProfileSettingsController() : base("/client/profile/settings")
        {
        }

        public override async Task RunAsync(HttpContext context)
        {
            var response = new ResponseBody<bool>()
            {
                data = true
            };

            await context.SendJsonAsync(Json.Stringify(response));
        }
    }
}