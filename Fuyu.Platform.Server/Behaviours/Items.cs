using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.IO;

namespace Fuyu.Platform.Server.Behaviours
{
    public class Items : FuyuBehaviour
    {
        private readonly string _response;

        public Items()
        {
            _response = Resx.GetText("fuyu", "database.client.items.json");
        }

        public override void Run(FuyuContext context)
        {
            SendJson(context, _response);
        }
    }
}