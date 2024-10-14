using System.Threading.Tasks;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Backend.BSG.DTO.Responses;
using Fuyu.Backend.EFT.DTO.Requests;

namespace Fuyu.Backend.EFT.Controllers
{
    public class MatchLocalEndController : HttpController<MatchLocalEndRequest>
    {
        public MatchLocalEndController() : base("/client/match/local/end")
        {
        }

        public override async Task RunAsync(HttpContext context, MatchLocalEndRequest body)
        {
            var sessionId = context.GetSessionId();
            var account = EftOrm.GetAccount(sessionId);

            // TODO:
            // * PVP-PVE state detection
            // -- seionmoya, 2024-08-28
            var profile = EftOrm.GetProfile(account.PveId);

            // save gear
            // TODO:
            // * scav / pmc state detection
            // -- seionmoya, 2024-08-28
            profile.Pmc = body.results.profile;
            EftOrm.SetOrAddProfile(profile);

            // send response
            var response = new ResponseBody<object>()
            {
                data = null
            };

            await context.SendJsonAsync(Json.Stringify(response));
        }
    }
}