using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Backend.BSG.DTO.Responses;
using Fuyu.Backend.EFT.DTO.Servers;

namespace Fuyu.Backend.EFT.Controllers
{
    public class ServerListController : HttpController
    {
        public ServerListController() : base("/client/server/list")
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