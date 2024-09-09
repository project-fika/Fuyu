using Fuyu.Common.Networking;

namespace Fuyu.Backend.EFT.Controllers
{
    public class HandbookTemplatesController : HttpController
    {
        public HandbookTemplatesController() : base("/client/handbook/templates")
        {
        }

        public override void Run(HttpContext context)
        {
            context.SendJson(EftOrm.GetHandbook());
        }
    }
}