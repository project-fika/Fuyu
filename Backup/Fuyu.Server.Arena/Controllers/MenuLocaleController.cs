using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Server.Arena.DTO.Responses;

namespace Fuyu.Server.Arena.Controllers
{
    public class MenuLocaleController : HttpController
    {
        public MenuLocaleController() : base("/client/menu/locale/{languageId}")
        {
        }

        public override void Run(HttpContext context)
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