using Fuyu.Platform.Server.Services;
using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.Models.EFT.Locations;
using Fuyu.Platform.Common.Models.EFT.Requests;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Server.Behaviours
{
    public class LocationGetLocalLoot : FuyuBehaviour
    {
        public override void Run(FuyuContext context)
        {
            var request = context.GetJson<LocationGetLocalLootRequest>();
            var location = LocationService.GetLocation(request.locationId, request.variantId);
            var response = new ResponseBody<Location>()
            {
                data = location
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}