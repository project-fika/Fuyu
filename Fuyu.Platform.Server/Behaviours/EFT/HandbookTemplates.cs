using Fuyu.Platform.Common.IO;
using Fuyu.Platform.Common.Networking;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class HandbookTemplates : HttpBehaviour
    {
        private readonly string _response;

        public HandbookTemplates() : base("/client/handbook/templates")
        {
            _response = Resx.GetText("eft", "database.eft.client.handbook.templates.json");
        }

        public override void Run(HttpContext context)
        {
            SendJson(context, _response);
        }
    }
}