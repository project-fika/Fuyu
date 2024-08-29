using Fuyu.Platform.Common.Hashing;
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

            // create savage
            var savageId = EftHash.Generate();
            account.EftSave.PvE.Savage = Json.Parse<Profile>(_savageJson);

            account.EftSave.PvE.Savage._id = savageId;
            account.EftSave.PvE.Savage.aid = accountId;

            // create pmc
            var pmcId = EftHash.Generate();
            account.EftSave.PvE.Pmc = request.side == "bear"
                ? Json.Parse<Profile>(_bearJson)
                : Json.Parse<Profile>(_usecJson);

            account.EftSave.PvE.Pmc._id                 = pmcId;
            account.EftSave.PvE.Pmc.savage              = savageId;
            account.EftSave.PvE.Pmc.aid                 = accountId;
            account.EftSave.PvE.Pmc.Info.Nickname       = account.Username;
            account.EftSave.PvE.Pmc.Info.LowerNickname  = account.Username.ToLowerInvariant();
            account.EftSave.PvE.Pmc.Info.Voice          = request.voiceId;
            account.EftSave.PvE.Pmc.Customization.Head  = request.headId;

            // wipe done
            account.EftSave.PvE.ShouldWipe = false;

            // store account
            FuyuDatabase.Accounts.SetAccount(accountId, account);

            // respond
            var response = new ResponseBody<GameProfileCreateResponse>()
            {
                data = new GameProfileCreateResponse()
                {
                    uid = pmcId
                }
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}