using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.IO;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class LocalGameWeather : FuyuBehaviour
    {
        private readonly string _response;

        public LocalGameWeather() : base("/client/localGame/weather")
        {
            _response = Resx.GetText("eft", "database.eft.client.localGame.weather.json");
        }

        public override void Run(FuyuContext context)
        {
            SendJson(context, _response);
        }
    }
}