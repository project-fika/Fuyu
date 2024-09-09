using Fuyu.Common.Networking;

namespace Fuyu.Backend.EFT.Controllers
{
    public class AccountCustomizationController : HttpController
    {
        public AccountCustomizationController() : base("/client/account/customization")
        {
        }

        public override void Run(HttpContext context)
        {
            context.SendJson(EftOrm.GetAccountCustomization());
        }
    }
}