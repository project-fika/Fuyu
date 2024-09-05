using Fuyu.Common.IO;
using Fuyu.Common.Networking;

namespace Fuyu.Server.EFT.Controllers
{
    public class HandbookTemplatesController : HttpController
    {
        private readonly string _response;

        public HandbookTemplatesController() : base("/client/handbook/templates")
        {
            _response = Resx.GetText("eft", "database.client.handbook.templates.json");
        }

        public override void Run(HttpContext context)
        {
            SendJson(context, _response);
        }
    }
}