using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.IO;

namespace Fuyu.Platform.Server.Behaviours
{
    public class HandbookTemplates : FuyuBehaviour
    {
        private readonly string _response;

        public HandbookTemplates()
        {
            _response = Resx.GetText("fuyu", "database.client.handbook.templates.json");
        }

        public override void Run(FuyuContext context)
        {
            SendJson(context, _response);
        }
    }
}