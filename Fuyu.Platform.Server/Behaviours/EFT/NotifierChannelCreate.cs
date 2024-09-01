using Fuyu.Platform.Common.Hashing;
using Fuyu.Platform.Common.Networking;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class NotifierChannelCreate : FuyuHttpBehaviour
    {
        public NotifierChannelCreate() : base("/client/notifier/channel/create")
        {
        }

        public override void Run(FuyuHttpContext context)
        {
            var channelId = SimpleId.Generate(64);
            var response = new ResponseBody<NotifierChannelCreateResponse>
            {
                data = new NotifierChannelCreateResponse()
                {
                    server = "localhost:8000",
                    channel_id = channelId,
                    url = string.Empty,
                    notifierServer = $"http://localhost:8000/push/notifier/get/{channelId}",
                    ws = $"ws://localhost:8000/push/notifier/getwebsocket/{channelId}"
                }
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}