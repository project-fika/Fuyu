using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Serialization;
using Fuyu.Platform.Server.Databases;
using System.Collections.Generic;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class MenuLocale : DynamicFuyuBehaviour
    {
        public override void RunDynamic(FuyuContext context, Dictionary<string, string> args)
        {
            var locale = EftDatabase.Locales.GetMenuLocale(args["locale"]);
            var response = new ResponseBody<MenuLocaleResponse>
            {
                data = locale
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}
