using System.Threading.Tasks;
using Fuyu.Common.Networking;

namespace Fuyu.Backend.EFT.Controllers
{
    public class TraderSettingsController : HttpController
    {
        public TraderSettingsController() : base("^/client/trading/api/traderSettings$")
        {
        }

        public override async Task RunAsync(HttpContext context)
        {
            await context.SendJsonAsync(EftOrm.GetTraders());
        }
    }
}