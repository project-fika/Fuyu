using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Server.BSG.DTO.Responses;
using Fuyu.Server.EFT.DTO.Responses;

namespace Fuyu.Server.EFT.Controllers
{
    public class CheckVersionController : HttpController
    {
        public CheckVersionController() : base("/client/checkVersion")
        {
        }

        public override void Run(HttpContext context)
        {
            var response = new ResponseBody<CheckVersionResponse>()
            {
                data = new CheckVersionResponse()
                {
                    isvalid = true,
                    latestVersion = "0.15.0.2.32197"
                }
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}