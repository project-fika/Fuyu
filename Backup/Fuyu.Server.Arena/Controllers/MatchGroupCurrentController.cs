using Fuyu.Backend.Arena.DTO.Responses;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;

namespace Fuyu.Backend.Arena.Controllers
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