using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Server.BSG.DTO.Responses;
using Fuyu.Server.EFT.DTO.Responses;

namespace Fuyu.Server.EFT.Controllers
{
    public class GetMetricsConfigController : HttpController
    {
        public GetMetricsConfigController() : base("/client/getMetricsConfig")
        {
        }

        public override void Run(HttpContext context)
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