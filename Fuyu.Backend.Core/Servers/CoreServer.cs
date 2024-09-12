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
            AddHttpController<AccountLoginController>();
            AddHttpController<AccountLogoutController>();
            AddHttpController<AccountRegisterController>();
            AddHttpController<AccountRegisterGameController>();
            AddHttpController<AccountGamesController>();
        }
    }
}