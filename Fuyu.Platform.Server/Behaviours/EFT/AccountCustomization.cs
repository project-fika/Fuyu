using Fuyu.Platform.Common.IO;
using Fuyu.Platform.Common.Networking;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class AccountCustomization : HttpBehaviour
    {
        private readonly string _response;

        public AccountCustomization() : base("/client/account/customization")
        {
            _response = Resx.GetText("eft", "database.eft.client.account.customization.json");
        }

        public override void Run(HttpContext context)
        {
            SendJson(context, _response);
        }
    }
}