using System.Threading.Tasks;
using Fuyu.Common.Networking;

namespace Fuyu.Backend.Core.Controllers
{
    public class AccountLogoutController : HttpController
    {
        public AccountLogoutController() : base("^/account/logout$")
        {
        }

        public override async Task RunAsync(HttpContext context)
        {
            var sessionId = context.GetSessionId();
            CoreOrm.RemoveSession(sessionId);

            await context.SendJsonAsync("{}");
        }
    }
}
