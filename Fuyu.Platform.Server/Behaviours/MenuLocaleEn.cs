using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.IO;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Server.Behaviours
{
    public class MenuLocaleEn : FuyuBehaviour
    {
        private readonly ResponseBody<MenuLocaleResponse> _response;

        public MenuLocaleEn()
        {
            var json = Resx.GetText("fuyu", "database.client.menu.locale-en.json");
            _response = Json.Parse<ResponseBody<MenuLocaleResponse>>(json);
        }

        public override void Run(FuyuContext context)
        {
            SendJson(context, Json.Stringify(_response));
        }
    }
}