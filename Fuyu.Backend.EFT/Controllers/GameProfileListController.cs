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

            if (profile.ShouldWipe)
            {
                profiles = [];
            }
            else
            {
                profiles = [profile.Pmc, profile.Savage];
            }

            var response = new ResponseBody<Profile[]>()
            {
                data = profiles
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}