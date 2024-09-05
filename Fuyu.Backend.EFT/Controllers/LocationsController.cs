using Fuyu.Common.IO;
using Fuyu.Backend.BSG.DTO.Responses;
using Fuyu.Backend.EFT.DTO.Locations;
using Fuyu.Backend.EFT.DTO.Responses;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;

namespace Fuyu.Backend.EFT.Controllers
{
    public class LocationsController : HttpController
    {
        private readonly ResponseBody<WorldMap> _locations;

        public LocationsController() : base("/client/locations")
        {
            var text = Resx.GetText("eft", "database.client.locations.json");
            _locations = Json.Parse<ResponseBody<WorldMap>>(text);
        }

        public override void Run(HttpContext context)
        {
            var response = Json.Stringify(_locations);
            SendJson(context, response);
        }
    }
}