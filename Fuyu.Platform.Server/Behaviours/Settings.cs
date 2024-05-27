using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.IO;

namespace Fuyu.Platform.Server.Behaviours
{
    public class Settings : FuyuBehaviour
    {
        private readonly string _response;

        public Settings()
        {
            _response = Resx.GetText("fuyu", "database.client.settings.json");
        }

        public override void Run(FuyuContext context)
        {
            SendJson(context, _response);
        }
    }
}