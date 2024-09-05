using Fuyu.Common.Networking;
using Fuyu.Server.Core.Controllers;

namespace Fuyu.Server.Core.Servers
{
    public class CoreServer : HttpServer
    {
        public CoreServer() : base("core", "http://localhost:8000")
        {
        }

        public override void RegisterServices()
        {
            AddHttpController<AccountLoginController>();
            AddHttpController<AccountRegisterController>();
            AddHttpController<AccountRegisterGameController>();
        }
    }
}