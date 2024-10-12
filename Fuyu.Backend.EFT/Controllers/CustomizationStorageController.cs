using System.Threading.Tasks;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Backend.BSG.DTO.Responses;
using Fuyu.Backend.EFT.DTO.Responses;

namespace Fuyu.Backend.EFT.Controllers
{
    public class CustomizationStorageController : HttpController
    {
        public CustomizationStorageController() : base("^/client/trading/customization/storage$")
        {
        }

        public override async Task RunAsync(HttpContext context)
        {
            var sessionId = context.GetSessionId();
            var account = EftOrm.GetAccount(sessionId);

            // TODO:
            // * PVP-PVE state detection
            // -- seionmoya, 2024/08/28
            var profile = EftOrm.GetProfile(account.PveId);

            var response = new ResponseBody<CustomizationStorageResponse>()
            {
                data = new CustomizationStorageResponse()
                {
                    _id = profile.Pmc._id,
                    suites = profile.Suites
                }
            };

            await context.SendJsonAsync(Json.Stringify(response));
        }
    }
}