using Fuyu.Platform.Common.IO;
using Fuyu.Platform.Common.Networking;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class HideoutQteList : HttpBehaviour
    {
        private readonly string _response;

        public HideoutQteList() : base("/client/hideout/qte/list")
        {
            _response = Resx.GetText("eft", "database.eft.client.hideout.qte.list.json");
        }

        public override void Run(HttpContext context)
        {
            SendJson(context, _response);
        }
    }
}