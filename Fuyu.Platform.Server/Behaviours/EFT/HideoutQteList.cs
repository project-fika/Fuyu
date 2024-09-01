using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.IO;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class HideoutQteList : FuyuHttpBehaviour
    {
        private readonly string _response;

        public HideoutQteList() : base("/client/hideout/qte/list")
        {
            _response = Resx.GetText("eft", "database.eft.client.hideout.qte.list.json");
        }

        public override void Run(FuyuHttpContext context)
        {
            SendJson(context, _response);
        }
    }
}