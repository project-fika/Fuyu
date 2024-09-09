using Fuyu.Backend.Arena.DTO.Multiplayer;
using Fuyu.Backend.Arena.DTO.Responses;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;

namespace Fuyu.Backend.Arena.Controllers
{
    public class ProfileStatusController : HttpController
    {
        public ProfileStatusController() : base("/client/profile/status")
        {
        }

        public override async Task RunAsync(HttpContext context)
        {
            var sessionId = context.GetSessionId();
            var account = ArenaOrm.GetAccount(sessionId);

            var response = new ResponseBody<ProfileStatusResponse>()
            {
                data = new ProfileStatusResponse()
                {
                    maxPveCountExceeded = false,
                    profiles =
                    [
                        new ProfileStatusInfo
                        {
                            profileid = account.EftSave.PvE.Pmc._id,
                            profileToken = null,
                            сanReconnectWithoutPenaltyUntil = 0,
                            status = "Free",
                            sid = string.Empty,
                            ip = string.Empty,
                            port = 0
                        },
                        new ProfileStatusInfo
                        {
                            profileid = account.EftSave.PvE.Savage._id,
                            profileToken = null,
                            сanReconnectWithoutPenaltyUntil = 0,
                            status = "Free",
                            sid = string.Empty,
                            ip = string.Empty,
                            port = 0
                        }
                    ]
                }
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}