using System.Collections.Generic;
using System.Threading.Tasks;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Backend.BSG.DTO.Responses;

namespace Fuyu.Backend.EFT.Controllers
{
    public class LanguagesController : HttpController
    {
        public LanguagesController() : base("/client/languages")
        {
        }

        public override async Task RunAsync(HttpContext context)
        {
            var languages = EftOrm.GetLanguages();
            var response = new ResponseBody<Dictionary<string, string>>
            {
                data = languages
            };

            await context.SendJsonAsync(Json.Stringify(response));
        }
    }
}