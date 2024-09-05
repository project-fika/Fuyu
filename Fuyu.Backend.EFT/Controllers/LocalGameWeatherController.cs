using Fuyu.Common.IO;
using Fuyu.Common.Networking;

namespace Fuyu.Backend.EFT.Controllers
{
    public class LocalGameWeatherController : HttpController
    {
        public LocalGameWeatherController() : base("/client/localGame/weather")
        {
        }

        public override void Run(HttpContext context)
        {
            SendJson(context, EftOrm.GetLocalWeather());
        }
    }
}