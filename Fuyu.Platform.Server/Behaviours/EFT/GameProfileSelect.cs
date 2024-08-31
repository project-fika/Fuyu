using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class GameProfileSelect : FuyuBehaviour
    {
        public GameProfileSelect() : base("/client/game/profile/select")
        {
        }

        public override void Run(FuyuContext context)
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