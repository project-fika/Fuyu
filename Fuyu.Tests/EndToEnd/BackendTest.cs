using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fuyu.Platform.Server.Servers;
using Fuyu.Platform.Server.Databases;
using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.Models.EFT.Bots;
using Fuyu.Platform.Common.Models.EFT.Requests;
using Fuyu.Platform.Common.Serialization;
using Fuyu.Platform.Common.Models.EFT.Profiles.Info;

namespace Fuyu.Tests.EndToEnd
{
    [TestClass]
    public class BackendTest
    {
        private static FuyuClient _client;

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext testContext)
        {
            _client = new FuyuClient("http://localhost:8000", "test");

            FuyuDatabase.Load();
            EftDatabase.Load();

            EftServer.Load();
            EftServer.Start();
        }

        [TestMethod]
        public async Task TestClientAccountCustomization()
        {
            var data = await _client.GetAsync("/client/account/customization");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientAchievementList()
        {
            var data = await _client.GetAsync("/client/achievement/list");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientAchievementStatistic()
        {
            var data = await _client.GetAsync("/client/achievement/statistic");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientBuildList()
        {
            var data = await _client.GetAsync("/client/builds/list");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientCheckVersion()
        {
            var data = await _client.GetAsync("/client/checkVersion");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientCustomization()
        {
            var data = await _client.GetAsync("/client/customization");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientTradingCustomizationStorage()
        {
            var data = await _client.GetAsync("/client/trading/customization/storage");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientFriendList()
        {
            var data = await _client.GetAsync("/client/friend/list");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientFriendRequestListInbox()
        {
            var data = await _client.GetAsync("/client/friend/request/list/inbox");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientFriendRequestListOutbox()
        {
            var data = await _client.GetAsync("/client/friend/request/list/outbox");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientGameBotGenerate()
        {
            // get request data
            var request = new GameBotGenerateRequest()
            {
                conditions = [
                    new BotCondition()
                    {
                        Role = EBotRole.assault,
                        Limit = 1,
                        Difficulty = EBotDifficulty.normal
                    }
                ]
            };

            // get request body
            var json = Json.Stringify(request);
            var body = Encoding.UTF8.GetBytes(json);

            // get response
            var data = await _client.PostAsync("/client/game/bot/generate", body);
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientGameConfig()
        {
            var data = await _client.GetAsync("/client/game/config");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientGameKeepalive()
        {
            var data = await _client.GetAsync("/client/game/keepalive");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientLogout()
        {
            var data = await _client.GetAsync("/client/game/logout");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientGameMode()
        {
            var data = await _client.GetAsync("/client/game/mode");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientGameProfileCreate()
        {
            // get request data
            var request = new GameProfileCreateRequest()
            {
                side        = "usec",
                nickname    = "senko",
                headId      = "5cde96047d6c8b20b577f016",
                voiceId     = "5fc614f40b735e7b024c76e9"
            };

            // get request body
            var json = Json.Stringify(request);
            var body = Encoding.UTF8.GetBytes(json);

            // get response
            var data = await _client.PostAsync("/client/game/profile/create", body);
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientGameProfileList()
        {
            var data = await _client.GetAsync("/client/game/profile/list");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientGameProfileNicknameReserved()
        {
            var data = await _client.GetAsync("/client/game/profile/nickname/reserved");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientGameProfileNicknameValidate()
        {
            // get request data
            var request = new GameProfileNicknameValidateRequest()
            {
                nickname = "senko"
            };

            // get request body
            var json = Json.Stringify(request);
            var body = Encoding.UTF8.GetBytes(json);

            // get response
            var data = await _client.PostAsync("/client/game/profile/nickname/validate", body);
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientGameProfileSelect()
        {
            var data = await _client.GetAsync("/client/game/profile/select");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientGameStart()
        {
            var data = await _client.GetAsync("/client/game/start");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientGameVersionValidate()
        {
            var data = await _client.GetAsync("/client/game/version/validate");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientGetMetricsConfig()
        {
            var data = await _client.GetAsync("/client/getMetricsConfig");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientGlobals()
        {
            var data = await _client.GetAsync("/client/globals");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientHandbookTemplates()
        {
            var data = await _client.GetAsync("/client/handbook/templates");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientHideoutAreas()
        {
            var data = await _client.GetAsync("/client/hideout/areas");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientProductionRecipes()
        {
            var data = await _client.GetAsync("/client/hideout/production/recipes");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientHideoutQteList()
        {
            var data = await _client.GetAsync("/client/hideout/qte/list");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientHideoutSettings()
        {
            var data = await _client.GetAsync("/client/hideout/settings");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientItems()
        {
            var data = await _client.GetAsync("/client/items");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientLanguages()
        {
            var data = await _client.GetAsync("/client/languages");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientLocaleCh()
        {
            var data = await _client.GetAsync("/client/locale/ch");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientLocaleCz()
        {
            var data = await _client.GetAsync("/client/locale/cz");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientLocaleEn()
        {
            var data = await _client.GetAsync("/client/locale/en");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientLocaleEs()
        {
            var data = await _client.GetAsync("/client/locale/es");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientLocaleEsMx()
        {
            var data = await _client.GetAsync("/client/locale/es-mx");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientLocaleFr()
        {
            var data = await _client.GetAsync("/client/locale/fr");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientLocaleGe()
        {
            var data = await _client.GetAsync("/client/locale/ge");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientLocaleHu()
        {
            var data = await _client.GetAsync("/client/locale/hu");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientLocaleIt()
        {
            var data = await _client.GetAsync("/client/locale/it");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientLocaleJp()
        {
            var data = await _client.GetAsync("/client/locale/jp");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientLocaleKr()
        {
            var data = await _client.GetAsync("/client/locale/kr");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientLocalePo()
        {
            var data = await _client.GetAsync("/client/locale/po");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientLocalePl()
        {
            var data = await _client.GetAsync("/client/locale/pl");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientLocaleRo()
        {
            var data = await _client.GetAsync("/client/locale/ro");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientLocaleRu()
        {
            var data = await _client.GetAsync("/client/locale/ru");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientLocaleSk()
        {
            var data = await _client.GetAsync("/client/locale/sk");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientLocaleTu()
        {
            var data = await _client.GetAsync("/client/locale/tu");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientLocalGameWeather()
        {
            var data = await _client.GetAsync("/client/localGame/weather");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientLocations()
        {
            var data = await _client.GetAsync("/client/locations");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientMailDialogList()
        {
            var data = await _client.GetAsync("/client/mail/dialog/list");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientMatchGroupCurrent()
        {
            var data = await _client.GetAsync("/client/match/group/current");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientMatchGroupExitFromMenu()
        {
            var data = await _client.GetAsync("/client/match/group/exit_from_menu");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientMatchGroupInviteCancelAll()
        {
            var data = await _client.GetAsync("/client/match/group/invite/cancel-all");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientMatchLocalEnd()
        {
            var data = await _client.GetAsync("/client/match/local/end");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientMatchLocalStart()
        {
            // get request data
            var request = new MatchLocalStartRequest()
            {
                location    = "factory4_day",
                timeVariant = "CURR",           // CURR: left, PAST: right
                mode        = "PVE",
                playerSide  = "PMC"
            };

            // get request body
            var json = Json.Stringify(request);
            var body = Encoding.UTF8.GetBytes(json);

            // get response
            var data = await _client.PostAsync("/client/match/local/start", body);
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientMenuLocaleCh()
        {
            var data = await _client.GetAsync("/client/menu/locale/ch");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientMenuLocaleCz()
        {
            var data = await _client.GetAsync("/client/menu/locale/cz");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientMenuLocaleEn()
        {
            var data = await _client.GetAsync("/client/menu/locale/en");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientMenuLocaleEs()
        {
            var data = await _client.GetAsync("/client/menu/locale/es");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientMenuLocaleEsMx()
        {
            var data = await _client.GetAsync("/client/menu/locale/es-mx");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientMenuLocaleFr()
        {
            var data = await _client.GetAsync("/client/menu/locale/fr");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientMenuLocaleGe()
        {
            var data = await _client.GetAsync("/client/menu/locale/ge");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientMenuLocaleHu()
        {
            var data = await _client.GetAsync("/client/menu/locale/hu");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientMenuLocaleIt()
        {
            var data = await _client.GetAsync("/client/menu/locale/it");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientMenuLocaleJp()
        {
            var data = await _client.GetAsync("/client/menu/locale/jp");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientMenuLocaleKr()
        {
            var data = await _client.GetAsync("/client/menu/locale/kr");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientMenuLocalePo()
        {
            var data = await _client.GetAsync("/client/menu/locale/po");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientMenuLocalePl()
        {
            var data = await _client.GetAsync("/client/menu/locale/pl");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientMenuLocaleRo()
        {
            var data = await _client.GetAsync("/client/menu/locale/ro");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientMenuLocaleRu()
        {
            var data = await _client.GetAsync("/client/menu/locale/ru");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientMenuLocaleSk()
        {
            var data = await _client.GetAsync("/client/menu/locale/sk");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientMenuLocaleTu()
        {
            var data = await _client.GetAsync("/client/menu/locale/tu");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestNotifierChannelCreate()
        {
            var data = await _client.GetAsync("/client/notifier/channel/create");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestProfileStatus()
        {
            var data = await _client.GetAsync("/client/profile/status");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestPutMetrics()
        {
            var data = await _client.GetAsync("/client/putMetrics");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestProfileSettings()
        {
            var data = await _client.GetAsync("/client/profile/settings");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientQuestList()
        {
            var data = await _client.GetAsync("/client/quest/list");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientRaidConfiguration()
        {
            var data = await _client.GetAsync("/client/raid/configuration");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientRepeatableQuestActivityPeriods()
        {
            var data = await _client.GetAsync("/client/repeatalbeQuests/activityPeriods");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientServerList()
        {
            var data = await _client.GetAsync("/client/server/list");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientSettings()
        {
            var data = await _client.GetAsync("/client/settings");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientSurvey()
        {
            var data = await _client.GetAsync("/client/survey");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientTradingApiTraderSettings()
        {
            var data = await _client.GetAsync("/client/trading/api/traderSettings");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public async Task TestClientWeather()
        {
            var data = await _client.GetAsync("/client/weather");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }
    }
}