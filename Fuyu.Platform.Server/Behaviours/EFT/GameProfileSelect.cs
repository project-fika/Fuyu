using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class GameProfileSelect : FuyuHttpBehaviour
    {
        public GameProfileSelect() : base("/client/game/profile/select")
        {
        }

        public override void Run(FuyuHttpContext context)
        {
            var response = new ResponseBody<ProfileSelectResponse>()
            {
                data = new ProfileSelectResponse()
                {
                    status = "ok"
                }
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}