using Fuyu.Server.Arena.DTO.Multiplayer;
using Fuyu.Server.Arena.DTO.Responses;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;

namespace Fuyu.Server.Arena.Controllers
{
    public class ProfileStatusController : HttpController
    {
        public ProfileStatusController() : base("/client/profile/status")
        {
        }

        public override void Run(HttpContext context)
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