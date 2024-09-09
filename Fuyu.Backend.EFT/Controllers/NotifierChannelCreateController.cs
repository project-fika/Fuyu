using Fuyu.Common.Hashing;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Backend.BSG.DTO.Responses;
using Fuyu.Backend.EFT.DTO.Responses;

namespace Fuyu.Backend.EFT.Controllers
{
    public class NotifierChannelCreateController : HttpController
    {
        public NotifierChannelCreateController() : base("/client/notifier/channel/create")
        {
        }

        public override void Run(HttpContext context)
        {
            var channelId = SimpleId.Generate(64);
            var response = new ResponseBody<NotifierChannelCreateResponse>
            {
                data = new NotifierChannelCreateResponse()
                {
                    server = "localhost:8010",
                    channel_id = channelId,
                    url = string.Empty,
                    notifierServer = $"http://localhost:8010/push/notifier/get/{channelId}",
                    ws = $"ws://localhost:8010/push/notifier/getwebsocket/{channelId}"
                }
            };

            context.SendJson(Json.Stringify(response));
        }
    }
}