using Fuyu.Platform.Common.Networking;
using Fuyu.Platform.Server.Behaviours.EFT;

namespace Fuyu.Platform.Server.Servers
{
    public class FuyuServer : HttpServer
    {
        public FuyuServer() : base("fuyu", "http://localhost:8000")
        {
        }

        public override void RegisterServices()
        {
            AddHttpBehaviour<AccountLogin>();
            AddHttpBehaviour<AccountRegister>();
            AddHttpBehaviour<AccountRegisterGame>();
        }
    }
}