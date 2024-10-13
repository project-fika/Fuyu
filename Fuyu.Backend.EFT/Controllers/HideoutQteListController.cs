using System.Threading.Tasks;
using Fuyu.Common.Networking;

namespace Fuyu.Backend.EFT.Controllers
{
    public class HideoutQteListController : HttpController
    {
        public HideoutQteListController() : base("/client/hideout/qte/list")
        {
        }

        public override async Task RunAsync(HttpContext context)
        {
            await context.SendJsonAsync(EftOrm.GetHideoutQteList());
        }
    }
}