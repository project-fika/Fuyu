using System.Threading.Tasks;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Backend.BSG.DTO.Responses;

namespace Fuyu.Backend.EFT.Controllers
{
    public class PutMetricsController : HttpController
    {
        public PutMetricsController() : base("/client/putMetrics")
        {
        }

        public override async Task RunAsync(HttpContext context)
        {
            var response = new ResponseBody<object>()
            {
                data = null
            };

            await context.SendJsonAsync(Json.Stringify(response));
        }
    }
}