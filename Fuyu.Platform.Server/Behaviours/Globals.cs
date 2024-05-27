using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.IO;

namespace Fuyu.Platform.Server.Behaviours
{
    public class Globals : FuyuBehaviour
    {
        private readonly string _response;

        public Globals()
        {
            _response = Resx.GetText("fuyu", "database.client.globals.json");
        }

        public override void Run(FuyuContext context)
        {
            SendJson(context, _response);
        }
    }
}