using System.Threading.Tasks;
using Fuyu.Common.Networking;

namespace Fuyu.Backend.EFT.Controllers
{
    public class HandbookTemplatesController : HttpController
    {
        public HandbookTemplatesController() : base("/client/handbook/templates")
        {
        }

        public override async Task RunAsync(HttpContext context)
        {
            await context.SendJsonAsync(EftOrm.GetHandbook());
        }
    }
}