using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Serialization;
using Fuyu.Platform.Server.Databases;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class MenuLocale : FuyuHttpBehaviour
    {
        public MenuLocale() : base("/client/menu/locale/{languageId}")
        {
        }

        public override void Run(FuyuHttpContext context)
        {
            var arguments = context.GetPathParameters(this);

            var languageId = arguments["languageId"];
            var locale = EftDatabase.Locales.GetMenuLocale(languageId);
            var response = new ResponseBody<MenuLocaleResponse>
            {
                data = locale
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}