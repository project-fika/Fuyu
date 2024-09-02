using Fuyu.Platform.Server.Services.EFT;
using Fuyu.Platform.Common.Models.EFT.Profiles;
using Fuyu.Platform.Common.Models.EFT.Requests;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Networking;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class GameBotGenerate : HttpBehaviour
    {
        public GameBotGenerate() : base("/client/game/bot/generate")
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