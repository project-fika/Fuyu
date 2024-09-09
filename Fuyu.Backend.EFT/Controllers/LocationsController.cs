using System.Threading.Tasks;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Backend.BSG.DTO.Responses;
using Fuyu.Backend.EFT.DTO.Locations;
using Fuyu.Backend.EFT.DTO.Responses;

namespace Fuyu.Backend.EFT.Controllers
{
    public class LocationsController : HttpController
    {
        public LocationsController() : base("/client/locations")
        {
        }

        public override async Task RunAsync(HttpContext context)
        {
            var json = EftOrm.GetLocations();
            var locations = Json.Parse<ResponseBody<WorldMap>>(json);
            var response = Json.Stringify(locations);
            await context.SendJsonAsync(response);
        }
    }
}