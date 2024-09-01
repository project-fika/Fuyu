using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Models.EFT.Servers;
using Fuyu.Platform.Common.Networking;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class ServerList : HttpBehaviour
    {
        public ServerList() : base("/client/server/list")
        {
        }

        public override void Run(HttpContext context)
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