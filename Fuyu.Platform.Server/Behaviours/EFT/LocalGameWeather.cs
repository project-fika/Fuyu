using Fuyu.Platform.Common.IO;
using Fuyu.Platform.Common.Networking;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class LocalGameWeather : HttpBehaviour
    {
        private readonly string _response;

        public LocalGameWeather() : base("/client/localGame/weather")
        {
            _response = Resx.GetText("eft", "database.eft.client.localGame.weather.json");
        }

        public override void Run(HttpContext context)
        {
            SendJson(context, _response);
        }
    }
}