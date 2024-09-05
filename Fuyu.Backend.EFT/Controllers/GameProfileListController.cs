using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Backend.BSG.DTO.Profiles;
using Fuyu.Backend.BSG.DTO.Responses;

namespace Fuyu.Backend.EFT.Controllers
{
    public class GameProfileListController : HttpController
    {
        public GameProfileListController() : base("/client/game/profile/list")
        {
        }

        public override void Run(HttpContext context)
        {
            var sessionId = context.GetSessionId();
            var account = EftOrm.GetAccount(sessionId);

            // TODO:
            // * PVP-PVE state detection
            // -- seionmoya, 2024/08/28
            var profile = EftOrm.GetProfile(account.PveId);
            Profile[] profiles;

            if (profile != null && !profile.ShouldWipe)
            {
                // profiles exist
                profiles = [profile.Pmc, profile.Savage];
            }
            else
            {
                // profile doesn't exist or must be wiped
                profiles = [];
            }

            var response = new ResponseBody<Profile[]>()
            {
                data = profiles
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}