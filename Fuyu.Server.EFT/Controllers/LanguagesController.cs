using System.Collections.Generic;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Server.BSG.DTO.Responses;

namespace Fuyu.Server.EFT.Controllers
{
    public class LanguagesController : HttpController
    {
        public LanguagesController() : base("/client/languages")
        {
        }

        public override void Run(HttpContext context)
        {
            var languages = EftOrm.GetLanguages();
            var response = new ResponseBody<Dictionary<string, string>>
            {
                data = languages
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}