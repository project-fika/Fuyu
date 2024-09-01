using Fuyu.Platform.Common.IO;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Networking;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class HideoutSettings : HttpBehaviour
    {
        private readonly ResponseBody<HideoutSettingsResponse> _response;

        public HideoutSettings() : base("/client/hideout/settings")
        {
            var json = Resx.GetText("eft", "database.eft.client.hideout.settings.json");
            _response = Json.Parse<ResponseBody<HideoutSettingsResponse>>(json);
        }

        public override void Run(HttpContext context)
        {
            SendJson(context, Json.Stringify(_response));
        }
    }
}