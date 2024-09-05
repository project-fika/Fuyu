using Fuyu.Common.IO;
using Fuyu.Backend.BSG.DTO.Responses;
using Fuyu.Backend.EFT.DTO.Responses;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;

namespace Fuyu.Backend.EFT.Controllers
{
    public class HideoutSettingsController : HttpController
    {
        private readonly ResponseBody<HideoutSettingsResponse> _response;

        public HideoutSettingsController() : base("/client/hideout/settings")
        {
            var json = Resx.GetText("eft", "database.client.hideout.settings.json");
            _response = Json.Parse<ResponseBody<HideoutSettingsResponse>>(json);
        }

        public override void Run(HttpContext context)
        {
            SendJson(context, Json.Stringify(_response));
        }
    }
}