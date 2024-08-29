using System.Collections.Generic;
using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Serialization;
using Fuyu.Platform.Server.Databases;

namespace Fuyu.Platform.Server.Behaviours
{
    public class LocalePo : FuyuBehaviour
    {
        public override void Run(FuyuContext context)
        {
            var locale = EftDatabase.Locales.GetGlobalLocale("po");
            var response = new ResponseBody<Dictionary<string, string>>
            {
                data = locale
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}