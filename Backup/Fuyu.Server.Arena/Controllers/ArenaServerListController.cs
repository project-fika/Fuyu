using Fuyu.Backend.Arena.DTO.Responses;
using Fuyu.Backend.Arena.DTO.Servers;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;

namespace Fuyu.Backend.Arena.Controllers
{
    public class ArenaServerListController : HttpController
    {
        public ArenaServerListController() : base("/client/arena/server/list")
        {
        }

        public override async Task RunAsync(HttpContext context)
        {
            var response = new ResponseBody<ServerInfo[]>()
            {
                data = [
                    new ServerInfo
                    {
                        Ip = "127.0.0.1",
                        DataCenter = "Offline",
                        Port = 8000,
                        IsSelected = true,
                        Hidden = false
                    }
                ]
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}