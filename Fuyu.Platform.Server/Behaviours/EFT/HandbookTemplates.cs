using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.IO;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class HandbookTemplates : FuyuBehaviour
    {
        private readonly string _response;

        public HandbookTemplates()
        {
            _response = Resx.GetText("eft", "database.eft.client.handbook.templates.json");
        }

        public override void Run(FuyuContext context)
        {
            SendJson(context, _response);
        }
    }
}