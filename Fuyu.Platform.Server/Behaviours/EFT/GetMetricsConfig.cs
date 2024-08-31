using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class GetMetricsConfig : FuyuBehaviour
    {
        public GetMetricsConfig() : base("/client/getMetricsConfig")
        {
        }

        public override void Run(FuyuContext context)
        {
            var response = new ResponseBody<GetMetricsConfigResponse>()
            {
                data = new GetMetricsConfigResponse()
                {
                    Keys = [0, 8, 10, 13, 16, 20, 26, 30, 33, 45, 53, 66, 100, 500, 750, 1000],
                    NetProcessingBins = [0, 1, 2, 3, 4, 5, 6, 7, 8, 10, 13, 16, 20, 26, 30, 33, 45, 53, 66, 100, 500, 750, 1000],
                    RenderBins = [0, 4, 8, 10, 13, 16, 20, 26, 30, 33, 45, 53, 66, 100, 500, 750, 1000],
                    GameUpdateBins = [0, 4, 8, 10, 13, 16, 20, 26, 30, 33, 45, 53, 66, 100, 500, 750, 1000],
                    MemoryMeasureInterval = 180,
                    PauseReasons = [1, 2, 4, 7]
                }
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}