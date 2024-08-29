using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Server.Behaviours
{
    public class CustomizationStorage : FuyuBehaviour
    {
        public override void Run(FuyuContext context)
        {
            var response = new ResponseBody<CustomizationStorageResponse>()
            {
                data = new CustomizationStorageResponse()
                {
                    _id = "664113fa049fd2369707c357",
                    suites = [
                        "5cde9ec17d6c8b04723cf479",
                        "5cde9e957d6c8b0474535da7"
                    ]
                }
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}