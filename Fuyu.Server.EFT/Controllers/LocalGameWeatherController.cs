using Fuyu.Common.IO;
using Fuyu.Common.Networking;

namespace Fuyu.Server.EFT.Controllers
{
    public class LocalGameWeatherController : HttpController
    {
        private readonly string _response;

        public LocalGameWeatherController() : base("/client/localGame/weather")
        {
            _response = Resx.GetText("eft", "database.client.localGame.weather.json");
        }

        public override void Run(HttpContext context)
        {
            SendJson(context, _response);
        }
    }
}