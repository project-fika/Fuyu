using Fuyu.Platform.Common.IO;
using Fuyu.Platform.Common.Networking;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class Weather : HttpBehaviour
    {
        private readonly string _response;

        public Weather() : base("/client/weather")
        {
            _response = Resx.GetText("eft", "database.eft.client.weather.json");
        }

        public override void Run(HttpContext context)
        {
            SendJson(context, _response);
        }
    }
}