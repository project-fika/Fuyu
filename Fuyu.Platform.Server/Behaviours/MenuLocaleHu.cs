using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Serialization;
using Fuyu.Platform.Server.Databases;

namespace Fuyu.Platform.Server.Behaviours
{
    public class MenuLocaleHu : FuyuBehaviour
    {
        public override void Run(FuyuContext context)
        {
            var locale = EftDatabase.Locales.GetMenuLocale("hu");
            var response = new ResponseBody<MenuLocaleResponse>
            {
                data = locale
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}