using Fuyu.Platform.Common.Networking;
using Fuyu.Platform.Common.IO;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class LocalGameWeather : FuyuHttpBehaviour
    {
        private readonly string _response;

        public LocalGameWeather() : base("/client/localGame/weather")
        {
            _response = Resx.GetText("eft", "database.eft.client.localGame.weather.json");
        }

        public override void Run(FuyuHttpContext context)
        {
            SendJson(context, _response);
        }
    }
}