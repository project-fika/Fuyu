using System.Collections.Generic;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Networking;
using Fuyu.Platform.Common.Serialization;
using Fuyu.Platform.Server.Databases;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class Languages : HttpBehaviour
    {
        public Languages() : base("/client/languages")
        {
        }

        public override void Run(HttpContext context)
        {
            var languages = EftDatabase.Locales.GetLanguages();
            var response = new ResponseBody<Dictionary<string, string>>
            {
                data = languages
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}