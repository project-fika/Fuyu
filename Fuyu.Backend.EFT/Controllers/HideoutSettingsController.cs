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

        public override void Run(HttpContext context)
        {
            var json = EftOrm.GetHideoutSettings();
            var response = Json.Parse<ResponseBody<HideoutSettingsResponse>>(json);
            context.SendJson(Json.Stringify(response));
        }
    }
}