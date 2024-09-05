using Fuyu.Common.Hashing;
using Fuyu.Common.IO;
using Fuyu.Common.Serialization;
using Fuyu.Server.BSG.DTO.Profiles.Info;
using Fuyu.Server.EFT.DTO.Accounts;

namespace Fuyu.Server.EFT.Services
{
    public static class ProfileService
    {
        public static string CreateProfile(EftAccount account, string side, string headId, string voiceId)
        {
            var profile = new EftProfile();
            var profiles = EftOrm.GetWipeProfile(account.Edition);

            // generate ids
            var pmcId = new MongoId(account.Id).ToString();
            var savageId = new MongoId(pmcId, 1, false).ToString();

            // create savage
            profile.Savage = profiles[EPlayerSide.Savage];

            profile.Savage._id = savageId;
            profile.Savage.aid = account.Id;

            // create pmc
            var voiceTemplate = EftOrm.GetCustomization(voiceId);

            profile.Pmc = side == "bear"
                ? profiles[EPlayerSide.Bear]
                : profiles[EPlayerSide.Usec];

            profile.Pmc._id                 = pmcId;
            profile.Pmc.savage              = savageId;
            profile.Pmc.aid                 = account.Id;
            profile.Pmc.Info.Nickname       = account.Username;
            profile.Pmc.Info.LowerNickname  = account.Username.ToLowerInvariant();
            profile.Pmc.Info.Voice          = voiceTemplate._name;
            profile.Pmc.Customization.Head  = headId;

            // wipe done
            profile.ShouldWipe = false;

            // store profile
            EftOrm.SetProfile(profile);
            WriteToDisk(profile);

            // update account
            // TODO:
            // * PVP-PVE state detection
            // -- seionmoya, 2024/08/28
            account.PveId = profile.Pmc._id;

            // store account
            EftOrm.SetAccount(account);
            AccountService.WriteToDisk(account);

            return profile.Pmc._id;
        }

        public static void WriteToDisk(EftProfile profile)
        {
            VFS.WriteTextFile(
                $"./Fuyu/Profiles/EFT/{profile.Pmc._id}.json",
                Json.Stringify(profile));
        }
    }
}