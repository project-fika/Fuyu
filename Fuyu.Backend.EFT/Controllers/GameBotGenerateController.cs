using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Backend.EFT.Services;
using Fuyu.Backend.BSG.DTO.Profiles;
using Fuyu.Backend.BSG.DTO.Responses;
using Fuyu.Backend.EFT.DTO.Requests;

namespace Fuyu.Backend.EFT.Controllers
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