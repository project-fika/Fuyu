using System.Threading.Tasks;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Backend.BSG.DTO.Responses;
using Fuyu.Backend.EFT.DTO.Responses;

namespace Fuyu.Backend.EFT.Controllers
{
    public class MatchGroupCurrentController : HttpController
    {
        public MatchGroupCurrentController() : base("/client/match/group/current")
        {
        }

        public override async Task RunAsync(HttpContext context)
        {
            var response = new ResponseBody<MatchGroupCurrentResponse>()
            {
                data = new MatchGroupCurrentResponse()
                {
                    squad = [],
                    raidSettings = null
                }
            };

            await context.SendJsonAsync(Json.Stringify(response));
        }
    }
}