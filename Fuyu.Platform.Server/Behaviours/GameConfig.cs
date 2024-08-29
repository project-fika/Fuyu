using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.IO;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Server.Behaviours
{
    public class GameConfig : FuyuBehaviour
    {
        private readonly ResponseBody<GameConfigResponse> _response;

        public GameConfig()
        {
            var json = Resx.GetText("fuyu", "database.client.game.config.json")
                .Replace("https://gw-pve.escapefromtarkov.com",    "http://localhost:8000")
                .Replace("https://gw-pve-04.escapefromtarkov.com", "http://localhost:8000")
                .Replace("wss://prod.escapefromtarkov.com",      "ws://localhost:8000");

            _response = Json.Parse<ResponseBody<GameConfigResponse>>(json);
        }

        public override void Run(FuyuContext context)
        {
            SendJson(context, Json.Stringify(_response));
        }
    }
}