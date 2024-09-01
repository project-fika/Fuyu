using Fuyu.Platform.Common.Networking;
using Fuyu.Platform.Common.IO;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class Weather : FuyuHttpBehaviour
    {
        private readonly string _response;

        public Weather() : base("/client/weather")
        {
            _response = Resx.GetText("eft", "database.eft.client.weather.json");
        }

        public override void Run(FuyuHttpContext context)
        {
            SendJson(context, _response);
        }
    }
}