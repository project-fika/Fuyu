using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Server.BSG.DTO.Responses;

namespace Fuyu.Server.EFT.Controllers
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

            SendJson(context, Json.Stringify(response));
        }
    }
}