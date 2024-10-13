using System.Threading.Tasks;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Backend.BSG.DTO.Responses;
using Fuyu.Backend.EFT.DTO.Responses;

namespace Fuyu.Backend.EFT.Controllers
{
    public class HideoutSettingsController : HttpController
    {
        public HideoutSettingsController() : base("/client/hideout/settings")
        {
        }

        public override async Task RunAsync(HttpContext context)
        {
            var json = EftOrm.GetHideoutSettings();
            var response = Json.Parse<ResponseBody<HideoutSettingsResponse>>(json);
            await context.SendJsonAsync(Json.Stringify(response));
        }
    }
}