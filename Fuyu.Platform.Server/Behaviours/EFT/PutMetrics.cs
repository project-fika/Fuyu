using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class PutMetrics : FuyuBehaviour
    {
        public PutMetrics() : base("/client/putMetrics")
        {
        }

        public override void Run(FuyuContext context)
        {
            var response = new ResponseBody<object>()
            {
                data = null
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}