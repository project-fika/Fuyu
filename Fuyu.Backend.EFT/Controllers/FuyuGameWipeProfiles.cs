using System.Threading.Tasks;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;

namespace Fuyu.Backend.EFT.Controllers
{
    public class FuyuGameWipeProfilesController : HttpController
    {
        public FuyuGameWipeProfilesController() : base("/fuyu/game/wipe/profiles")
        {
        }

        public override Task RunAsync(HttpContext context)
        {
            var response = EftOrm.GetWipeProfiles().Keys;

            return context.SendJsonAsync(Json.Stringify(response));
        }
    }
}