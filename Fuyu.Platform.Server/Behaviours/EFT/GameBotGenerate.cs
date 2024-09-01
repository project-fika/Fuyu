using Fuyu.Platform.Server.Services;
using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.Models.EFT.Profiles;
using Fuyu.Platform.Common.Models.EFT.Requests;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class GameBotGenerate : FuyuBehaviour
    {
        public GameBotGenerate() : base("/client/game/bot/generate")
        {
        }

        public override void Run(FuyuHttpContext context)
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