using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Server.BSG.DTO.Responses;
using Fuyu.Server.EFT.DTO.Responses;

namespace Fuyu.Server.EFT.Controllers
{
    public class MatchGroupCurrentController : HttpController
    {
        public MatchGroupCurrentController() : base("/client/match/group/current")
        {
        }

        public override void Run(HttpContext context)
        {
            var response = new ResponseBody<MatchGroupCurrentResponse>()
            {
                data = new MatchGroupCurrentResponse()
                {
                    squad = []
                }
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}