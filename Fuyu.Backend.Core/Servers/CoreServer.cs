using Fuyu.Common.Networking;
using Fuyu.Backend.Core.Controllers;

namespace Fuyu.Backend.Core.Servers
{
    public class CoreServer : HttpServer
    {
        public CoreServer() : base("core", "http://localhost:8000/")
        {
        }

        public void RegisterServices()
        {
            HttpRouter.AddController<AccountLoginController>();
            HttpRouter.AddController<AccountLogoutController>();
            HttpRouter.AddController<AccountRegisterController>();
            HttpRouter.AddController<AccountRegisterGameController>();
            HttpRouter.AddController<AccountGamesController>();
        }
    }
}