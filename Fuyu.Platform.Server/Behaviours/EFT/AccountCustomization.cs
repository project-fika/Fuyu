using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.IO;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class AccountCustomization : FuyuBehaviour
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