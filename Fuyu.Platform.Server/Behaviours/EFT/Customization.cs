using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.IO;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class Customization : FuyuBehaviour
    {
        private readonly string _response;

        public Customization()
        {
            _response = Resx.GetText("eft", "database.eft.client.customization.json");
        }

        public override void Run(FuyuContext context)
        {
            SendJson(context, _response);
        }
    }
}