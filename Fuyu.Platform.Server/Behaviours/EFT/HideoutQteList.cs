using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.IO;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class HideoutQteList : FuyuBehaviour
    {
        private readonly string _response;

        public HideoutQteList()
        {
            _response = Resx.GetText("eft", "database.eft.client.hideout.qte.list.json");
        }

        public override void Run(FuyuContext context)
        {
            SendJson(context, _response);
        }
    }
}