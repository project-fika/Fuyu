using Fuyu.Common.IO;
using Fuyu.Common.Networking;

namespace Fuyu.Backend.EFT.Controllers
{
    public class WeatherController : HttpController
    {
        private readonly string _response;

        public WeatherController() : base("/client/weather")
        {
            _response = Resx.GetText("eft", "database.client.weather.json");
        }

        public override void Run(HttpContext context)
        {
            SendJson(context, _response);
        }
    }
}