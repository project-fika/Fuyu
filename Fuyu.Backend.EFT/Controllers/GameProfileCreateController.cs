using Fuyu.Common.Hashing;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Backend.BSG.DTO.Profiles;
using Fuyu.Backend.BSG.DTO.Profiles.Info;
using Fuyu.Backend.BSG.DTO.Responses;
using Fuyu.Backend.EFT.DTO.Requests;
using Fuyu.Backend.EFT.DTO.Responses;
using Fuyu.Backend.EFT.Services;

namespace Fuyu.Backend.EFT.Controllers
{
    // TODO:
    // * move code into TemplateTable and ProfileService
    // -- seionmoya, 2024/09/02
    public class GameProfileCreateController : HttpController
    {
        public GameProfileCreateController() : base("/client/game/profile/create")
        {
        }

        public override void Run(HttpContext context)
        {
            var request = context.GetJson<GameProfileCreateRequest>();
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

            context.SendJson(Json.Stringify(response));
        }
    }
}