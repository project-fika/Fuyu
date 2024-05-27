using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Server.Behaviours
{
    public class GameProfileSelect : FuyuBehaviour
    {
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