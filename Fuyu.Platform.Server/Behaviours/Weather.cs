using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.IO;

namespace Fuyu.Platform.Server.Behaviours
{
    public class Weather : FuyuBehaviour
    {
        private readonly string _response;

        public Weather()
        {
            _response = Resx.GetText("fuyu", "database.client.weather.json");
        }

        public override void Run(FuyuContext context)
        {
            SendJson(context, _response);
        }
    }
}