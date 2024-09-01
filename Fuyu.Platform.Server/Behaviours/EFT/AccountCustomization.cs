using Fuyu.Platform.Common.Networking;
using Fuyu.Platform.Common.IO;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class AccountCustomization : FuyuHttpBehaviour
    {
        private readonly string _response;

        public AccountCustomization() : base("/client/account/customization")
        {
            _response = Resx.GetText("eft", "database.eft.client.account.customization.json");
        }

        public override void Run(FuyuHttpContext context)
        {
            SendJson(context, _response);
        }
    }
}