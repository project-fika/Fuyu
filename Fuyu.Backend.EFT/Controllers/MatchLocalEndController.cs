using System.Threading.Tasks;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Backend.BSG.DTO.Responses;
using Fuyu.Backend.EFT.DTO.Requests;
using System.Linq;

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

			// NOTE: This data is not present in what the client sends as one of BSG's anticheat measures
            // which prevents your inraid inventory info from knowing what is in someone's stash
            // so I have to manually add the existing data that should be there which I think is ;ess effort
            // than manually taking the data that we want from the client's request
			// -- nexus4880, 2024-10-14
			body.results.profile.Info.LowerNickname = profile.Pmc.Info.LowerNickname;

			body.results.profile.Inventory.stash = profile.Pmc.Inventory.stash;
            body.results.profile.Inventory.questStashItems = profile.Pmc.Inventory.questStashItems;

            var stash = profile.Pmc.Inventory.items.First(i => i._id == profile.Pmc.Inventory.stash);
            var questStashItems = profile.Pmc.Inventory.items.First(i => i._id == profile.Pmc.Inventory.questStashItems);

			body.results.profile.Inventory.items = body.results.profile.Inventory.items.Prepend(stash).Prepend(questStashItems).ToArray();

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