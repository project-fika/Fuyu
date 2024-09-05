using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Server.EFT.Services;
using Fuyu.Server.BSG.DTO.Profiles;
using Fuyu.Server.BSG.DTO.Responses;
using Fuyu.Server.EFT.DTO.Requests;

namespace Fuyu.Server.EFT.Controllers
{
    public class GameBotGenerateController : HttpController
    {
        public GameBotGenerateController() : base("/client/game/bot/generate")
        {
        }

        public override void Run(HttpContext context)
        {
            var request = context.GetJson<GameBotGenerateRequest>();
            var profiles = BotService.GetBots(request.conditions);
            var response = new ResponseBody<Profile[]>()
            {
                data = profiles
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}