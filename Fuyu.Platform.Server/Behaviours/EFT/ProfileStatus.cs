using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.Models.EFT.Multiplayer;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Serialization;
using Fuyu.Platform.Server.Databases;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class ProfileStatus : FuyuHttpBehaviour
    {
        public ProfileStatus() : base("/client/profile/status")
        {
        }

        public override void Run(FuyuHttpContext context)
        {
            var sessionId = context.GetSessionId();
            var account = FuyuDatabase.Accounts.GetAccount(sessionId);

            // TODO: PVP-PVE STATE DETECTION

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
                            status = "Free",
                            sid = string.Empty,
                            ip = string.Empty,
                            port = 0
                        },
                        new ProfileStatusInfo
                        {
                            profileid = account.EftSave.PvE.Savage._id,
                            profileToken = null,
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