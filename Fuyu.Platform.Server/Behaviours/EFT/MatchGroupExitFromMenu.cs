using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class MatchGroupExitFromMenu : FuyuBehaviour
    {
        public MatchGroupExitFromMenu() : base("/client/match/group/exit_from_menu")
        {
        }

        public override void Run(FuyuHttpContext context)
        {
            var response = new ResponseBody<object>()
            {
                data = null
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}