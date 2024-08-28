using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.IO;

namespace Fuyu.Platform.Server.Behaviours
{
    public class LocalGameWeather : FuyuBehaviour
    {
        private readonly string _response;

        public LocalGameWeather()
        {
            _response = Resx.GetText("fuyu", "database.client.localGame.weather.json");
        }

        public override void Run(FuyuContext context)
        {
            SendJson(context, _response);
        }
    }
}