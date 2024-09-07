using Fuyu.Common.Networking;

namespace Fuyu.Backend.EFT.Controllers
{
    public class WeatherController : HttpController
    {
        public WeatherController() : base("/client/weather")
        {
        }

        public override void Run(HttpContext context)
        {
            SendJson(context, EftOrm.GetWeather());
        }
    }
}