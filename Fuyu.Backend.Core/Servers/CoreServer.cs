using Fuyu.Common.Networking;
using Fuyu.Backend.Core.Controllers;

namespace Fuyu.Backend.Core.Servers
{
    public class CoreServer : HttpServer
    {
        public CoreServer() : base("core", "http://localhost:8000/")
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