using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Models.EFT.Servers;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Server.Behaviours
{
    public class ServerList : FuyuBehaviour
    {
        public override void Run(FuyuContext context)
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