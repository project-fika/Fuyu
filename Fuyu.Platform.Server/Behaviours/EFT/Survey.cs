using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Networking;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class Survey : HttpBehaviour
    {
        public Survey() : base("/client/survey")
        {
        }

        public override void Run(HttpContext context)
        {
            var response = new ResponseBody<object>()
            {
                data = null
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}