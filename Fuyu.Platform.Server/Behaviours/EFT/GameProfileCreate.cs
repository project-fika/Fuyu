using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.IO;
using Fuyu.Platform.Common.Models.EFT.Profiles;
using Fuyu.Platform.Common.Models.EFT.Requests;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Serialization;
using Fuyu.Platform.Server.Databases;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class GameProfileCreate : FuyuBehaviour
    {
        private readonly string _bearJson;
        private readonly string _usecJson;
        private readonly string _savageJson;

        public GameProfileCreate()
        {
            _bearJson = Resx.GetText("eft", "database.eft.profiles.player.unheard-bear.json");
            _usecJson = Resx.GetText("eft", "database.eft.profiles.player.unheard-usec.json");
            _savageJson = Resx.GetText("eft", "database.eft.profiles.player.savage.json");
        }

        public override void Run(FuyuContext context)
        {
            var request = context.GetJson<GameProfileCreateRequest>();
            var sessionId = context.GetSessionId();
            var accountId = FuyuDatabase.Accounts.GetSession(sessionId);
            var account = FuyuDatabase.Accounts.GetAccount(accountId);

            // TODO: PVP-PVE STATE DETECTION
            var pve = account.EftSave.PvE;

            // create savage
            pve.Savage = Json.Parse<Profile>(_savageJson);

            pve.Savage._id = "000000000000000000000002";    // TODO: generate this
            pve.Savage.aid = accountId;

            // create pmc
            pve.Pmc = request.side == "bear"
                ? Json.Parse<Profile>(_bearJson)
                : Json.Parse<Profile>(_usecJson);

            pve.Pmc._id = "000000000000000000000001";       // TODO: generate this
            pve.Pmc.savage = pve.Savage._id;
            pve.Pmc.aid = accountId;
            pve.Pmc.Info.Nickname = account.Username;
            pve.Pmc.Info.LowerNickname = account.Username.ToLowerInvariant();
            pve.Pmc.Info.Voice = request.voiceId;
            pve.Pmc.Customization.Head = request.headId;

            // wipe done
            pve.ShouldWipe = false;

            // store account
            FuyuDatabase.Accounts.SetAccount(accountId, account);

            // respond
            var response = new ResponseBody<GameProfileCreateResponse>()
            {
                data = new GameProfileCreateResponse()
                {
                    uid = pve.Pmc._id
                }
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}