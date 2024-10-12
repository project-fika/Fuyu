using System.Threading.Tasks;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Backend.BSG.DTO.Profiles;
using Fuyu.Backend.BSG.DTO.Responses;

namespace Fuyu.Backend.EFT.Controllers
{
    public class GameProfileListController : HttpController
    {
        public GameProfileListController() : base("^/client/game/profile/list$")
        {
        }

        public override async Task RunAsync(HttpContext context)
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

            await context.SendJsonAsync(Json.Stringify(response));
        }
    }
}