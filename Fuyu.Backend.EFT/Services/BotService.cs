using System.Collections.Generic;
using Fuyu.Backend.BSG.DTO.Bots;
using Fuyu.Backend.BSG.DTO.Profiles;
using Fuyu.Backend.EFT.DTO.Bots;
using Fuyu.Common.Hashing;
using Fuyu.Common.IO;
using Fuyu.Common.Serialization;

namespace Fuyu.Backend.EFT.Services
{
    // NOTE: regarding how BotService is designed;
    // - the goal is to make a very simple bot generator that can easily be
    //   replaced by mods
    // - profiles are not stored in EftDatabase because ideally a completely
    //   different generation system not depending on this data
    // -- seionmoya, 2024-10-21
    public static class BotService
    {
        private static Dictionary<EBotRole, string> _profiles;
        
        static BotService()
        {
            _profiles = new Dictionary<EBotRole, string>()
            {
                { EBotRole.marksman, Resx.GetText("eft", "database.bots.marksman.json") },
                { EBotRole.assault, Resx.GetText("eft", "database.bots.assault.json") },
                { EBotRole.bossTest, null },
                { EBotRole.bossBully, null },
                { EBotRole.followerTest, null },
                { EBotRole.followerBully, null },
                { EBotRole.bossKilla, null },
                { EBotRole.bossKojaniy, null },
                { EBotRole.followerKojaniy, null },
                { EBotRole.pmcBot, null },
                { EBotRole.cursedAssault, null },
                { EBotRole.bossGluhar, null },
                { EBotRole.followerGluharAssault, null },
                { EBotRole.followerGluharSecurity, null },
                { EBotRole.followerGluharScout, null },
                { EBotRole.followerGluharSnipe, null },
                { EBotRole.followerSanitar, null },
                { EBotRole.test, null },
                { EBotRole.assaultGroup, null },
                { EBotRole.sectantWarrior, null },
                { EBotRole.sectantPriest, null },
                { EBotRole.bossTagilla, Resx.GetText("eft", "database.bots.bosstagilla.json") },
                { EBotRole.followerTagilla, null },
                { EBotRole.exUsec, null },
                { EBotRole.gifter, null },
                { EBotRole.bossKnight, null },
                { EBotRole.followerBigPipe, null },
                { EBotRole.followerBirdEye, null },
                { EBotRole.bossZryachiy, null },
                { EBotRole.followerZryachiy, null },
                { EBotRole.bossBoar, null },
                { EBotRole.followerBoar, null },
                { EBotRole.arenaFighter, null },
                { EBotRole.arenaFighterEvent, null },
                { EBotRole.bossBoarSniper, null },
                { EBotRole.crazyAssaultEvent, null },
                { EBotRole.peacefullZryachiyEvent, null },
                { EBotRole.sectactPriestEvent, null },
                { EBotRole.ravangeZryachiyEvent, null },
                { EBotRole.followerBoarClose1, null },
                { EBotRole.followerBoarClose2, null },
                { EBotRole.bossKolontay, null },
                { EBotRole.followerKolontayAssault, null },
                { EBotRole.followerKolontaySecurity, null },
                { EBotRole.shooterBTR, null },
                { EBotRole.bossPartisan, null },
                { EBotRole.spiritWinter, null },
                { EBotRole.spiritSpring, null },
                { EBotRole.peacemaker, null },
                { EBotRole.pmcBEAR, null },
                { EBotRole.pmcUSEC, null },
                { EBotRole.skier, null }
            };
        }

        public static Profile[] GetBots(BotCondition[] conditions)
        {
            var profiles = new List<Profile>();

            foreach (var condition in conditions)
            {
                // generate amount for profile type
                for (var i = 0; i < condition.Limit; ++i)
                {
                    var profile = GenerateBot(condition.Role);
                    profiles.Add(profile);
                }
            }

            return profiles.ToArray();
        }

        private static Profile GenerateBot(EBotRole role)
        {
            var profile = Json.Parse<Profile>(_profiles[role]);

            // regenerate all ids
            profile._id = new MongoId(true);
            ItemService.RegenerateItemIds(profile.Inventory.items);

            return profile;
        }
    }
}