using System.Threading.Tasks;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Backend.BSG.DTO.Responses;
using Fuyu.Backend.EFT.DTO.Requests;
using Fuyu.Backend.EFT.DTO.Responses;
using Fuyu.Backend.EFT.Services;

namespace Fuyu.Backend.EFT.Controllers
{
    // TODO:
    // * move code into TemplateTable and ProfileService
    // -- seionmoya, 2024/09/02
    public class GameProfileCreateController : BodyAwareHttpController<GameProfileCreateRequest>
    {
        public GameProfileCreateController() : base("/client/game/profile/create")
        {
        }

        public override Task RunAsync(HttpContext context, GameProfileCreateRequest request)
        {
            var sessionId = context.GetSessionId();
            var accountId = EftOrm.GetSession(sessionId);
            var account = EftOrm.GetAccount(accountId);
            var pmcId = ProfileService.WipeProfile(account, request.side, request.headId, request.voiceId);
            var response = new ResponseBody<GameProfileCreateResponse>()
            {
                data = new GameProfileCreateResponse()
                {
                    uid = pmcId
                }
            };

            return context.SendJsonAsync(Json.Stringify(response));
        }
    }
}