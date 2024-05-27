using Fuyu.Platform.Server.Services;
using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.Models.EFT.Locations;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Server.Behaviours
{
    public class Locations : FuyuBehaviour
    {
        public override void Run(FuyuContext context)
        {
            var worldmap = LocationService.GetWorldMap();
            var response = new ResponseBody<WorldMap>()
            {
                data = worldmap
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}