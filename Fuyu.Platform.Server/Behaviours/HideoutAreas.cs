using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.IO;

namespace Fuyu.Platform.Server.Behaviours
{
    public class HideoutAreas : FuyuBehaviour
    {
        private readonly string _response;

        public HideoutAreas()
        {
            _response = Resx.GetText("fuyu", "database.client.hideout.areas.json");
        }

        public override void Run(FuyuContext context)
        {
            SendJson(context, _response);
        }
    }
}