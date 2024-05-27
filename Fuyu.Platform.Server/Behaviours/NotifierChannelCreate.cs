using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.IO;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Server.Behaviours
{
    public class NotifierChannelCreate : FuyuBehaviour
    {
        private readonly ResponseBody<NotifierChannelCreateResponse> _response;

        public NotifierChannelCreate()
        {
            var json = Resx.GetText("fuyu", "database.client.notifier.channel.create.json")
                .Replace("https://", "http://")
                .Replace("wss://", "ws://")
                .Replace("wsn-01.escapefromtarkov.com", "localhost:8000");

            _response = Json.Parse<ResponseBody<NotifierChannelCreateResponse>>(json);
        }

        public override void Run(FuyuContext context)
        {
            SendJson(context, Json.Stringify(_response));
        }
    }
}