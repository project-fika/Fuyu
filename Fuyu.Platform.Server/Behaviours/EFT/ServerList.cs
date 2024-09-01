using Fuyu.Platform.Common.Networking;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Models.EFT.Servers;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class ServerList : FuyuHttpBehaviour
    {
        public ServerList() : base("/client/server/list")
        {
        }

        public override void Run(FuyuHttpContext context)
        {
            var response = new ResponseBody<ServerInfo[]>()
            {
                data = [
                    new ServerInfo
                    {
                        ip = "127.0.0.1",
                        port = 8000
                    }
                ]
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}