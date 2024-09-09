using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Backend.BSG.DTO.Responses;

namespace Fuyu.Backend.EFT.Controllers
{
    public class ProfileSettingsController : HttpController
    {
        public ProfileSettingsController() : base("/client/profile/settings")
        {
        }

        public override void Run(HttpContext context)
        {
            var response = new ResponseBody<bool>()
            {
                data = true
            };

            context.SendJson(Json.Stringify(response));
        }
    }
}