using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.Models.EFT.Multiplayer;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Serialization;
using Fuyu.Platform.Server.Databases;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class ProfileStatus : FuyuBehaviour
    {
        public override void Run(FuyuContext context)
        {
            var sessionId = context.GetSessionId();
            var accountId = FuyuDatabase.Accounts.GetSession(sessionId);
            var account = FuyuDatabase.Accounts.GetAccount(accountId);

            // TODO: PVP-PVE STATE DETECTION
            var pve = account.EftSave.PvE;

            var response = new ResponseBody<ProfileStatusResponse[]>()
            {
                data =
                [
                    new ProfileStatusResponse()
                    {
                        maxPveCountExceeded = false,
                        profiles =
                        [
                            new ProfileStatusInfo
                            {
                                profileid = pve.Pmc._id,
                                profileToken = null,
                                status = "Free",
                                sid = string.Empty,
                                ip = string.Empty,
                                port = 0
                            },
                            new ProfileStatusInfo
                            {
                                profileid = pve.Savage._id,
                                profileToken = null,
                                status = "Free",
                                sid = string.Empty,
                                ip = string.Empty,
                                port = 0
                            }
                        ]
                    }
                ]
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}