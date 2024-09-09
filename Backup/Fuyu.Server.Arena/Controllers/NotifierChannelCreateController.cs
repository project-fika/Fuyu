using Fuyu.Common.Hashing;
using Fuyu.Backend.Arena.DTO.Responses;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;

namespace Fuyu.Backend.Arena.Controllers
{
    public class NotifierChannelCreateController : HttpController
    {
        public NotifierChannelCreateController() : base("/client/notifier/channel/create")
        {
        }

        public override async Task RunAsync(HttpContext context)
        {
            var channelId = SimpleId.Generate(64);
            var response = new ResponseBody<NotifierChannelCreateResponse>
            {
                data = new NotifierChannelCreateResponse()
                {
                    server = "localhost:8020",
                    channel_id = channelId,
                    url = string.Empty,
                    notifierServer = $"http://localhost:8020/push/notifier/get/{channelId}",
                    ws = $"ws://localhost:8020/push/notifier/getwebsocket/{channelId}"
                }
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}