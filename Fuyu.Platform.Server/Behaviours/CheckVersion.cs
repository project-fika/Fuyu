using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Server.Behaviours
{
    public class CheckVersion : FuyuBehaviour
    {
        public override void Run(FuyuContext context)
        {
            var response = new ResponseBody<CheckVersionResponse>()
            {
                data = new CheckVersionResponse()
                {
                    isvalid = true,
                    latestVersion = "0.14.1.2.29197"
                }
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}