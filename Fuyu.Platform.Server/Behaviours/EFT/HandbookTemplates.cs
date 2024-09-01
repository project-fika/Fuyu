using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.IO;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class HandbookTemplates : FuyuBehaviour
    {
        private readonly string _response;

        public HandbookTemplates() : base("/client/handbook/templates")
        {
            _response = Resx.GetText("eft", "database.eft.client.handbook.templates.json");
        }

        public override void Run(FuyuHttpContext context)
        {
            SendJson(context, _response);
        }
    }
}