using System.Threading.Tasks;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Backend.BSG.DTO.Responses;
using Fuyu.Backend.EFT.DTO.Responses;
using System.Text.RegularExpressions;

namespace Fuyu.Backend.EFT.Controllers
{
    public partial class MenuLocaleController : HttpController
    {
        [GeneratedRegex("^/client/menu/locale/(?<languageId>[a-z]+(-[a-z]+)?)$")]
        private static partial Regex PathExpression();

        public MenuLocaleController() : base(PathExpression())
        {
        }

        public override async Task RunAsync(HttpContext context)
        {
            var parameters = context.GetPathParameters(this);

            var languageId = parameters["languageId"];
            var locale = EftOrm.GetMenuLocale(languageId);
            var response = new ResponseBody<MenuLocaleResponse>
            {
                data = locale
            };

            await context.SendJsonAsync(Json.Stringify(response));
        }
    }
}
