using System.Threading.Tasks;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Backend.BSG.DTO.Profiles;
using Fuyu.Backend.BSG.DTO.Responses;
using Fuyu.Backend.EFT.DTO.Requests;
using Fuyu.Backend.EFT.Services;

namespace Fuyu.Backend.EFT.Controllers
{
    public class GameBotGenerateController : HttpController
    {
        public GameBotGenerateController() : base("/client/game/bot/generate")
        {
        }

        public override async Task RunAsync(HttpContext context)
        {
            var request = await context.GetJsonAsync<GameBotGenerateRequest>();
            var profiles = BotService.GetBots(request.conditions);
            var response = new ResponseBody<Profile[]>()
            {
                data = profiles
            };

            await context.SendJsonAsync(Json.Stringify(response));
        }
    }
}