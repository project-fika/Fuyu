using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Backend.Arena.DTO.Responses;

namespace Fuyu.Backend.Arena.Controllers
{
    public class MenuLocaleController : HttpController
    {
        public MenuLocaleController() : base("/client/menu/locale/{languageId}")
        {
        }

        public override async Task RunAsync(HttpContext context)
        {
            var parameters = context.GetPathParameters(this);

            var languageId = parameters["languageId"];
            var locale = ArenaOrm.GetMenuLocale(languageId);
            var response = new ResponseBody<MenuLocaleResponse>
            {
                data = locale
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}