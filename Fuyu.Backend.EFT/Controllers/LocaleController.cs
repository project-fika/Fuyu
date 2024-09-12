using System.Threading.Tasks;
using System.Collections.Generic;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Backend.BSG.DTO.Responses;

namespace Fuyu.Backend.EFT.Controllers
{
    public class LocaleController : HttpController
    {
        public LocaleController() : base("/client/locale/{languageId}")
        {
        }

        public override async Task RunAsync(HttpContext context)
        {
            var parameters = context.GetPathParameters(this);

            var languageId = parameters["languageId"];
            var locale = EftOrm.GetGlobalLocale(languageId);
            var response = new ResponseBody<Dictionary<string, string>>
            {
                data = locale
            };

            await context.SendJsonAsync(Json.Stringify(response));
        }
    }
}