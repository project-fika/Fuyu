using System.Collections.Generic;
using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.IO;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Server.Behaviours
{
    public class LocaleEn : FuyuBehaviour
    {
        private readonly ResponseBody<Dictionary<string, string>> _response;

        public LocaleEn()
        {
            var json = Resx.GetText("fuyu", "database.client.locale-en.json");
            _response = Json.Parse<ResponseBody<Dictionary<string, string>>>(json);
        }

        public override void Run(FuyuContext context)
        {
            SendJson(context, Json.Stringify(_response));
        }
    }
}