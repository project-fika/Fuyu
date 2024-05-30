using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fuyu.Platform.Server;
using Fuyu.Platform.Server.Databases;
using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.Models.EFT.Bots;
using Fuyu.Platform.Common.Models.EFT.Requests;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Tests.EndToEnd
{
    [TestClass]
    public class BackendTest
    {
        private static FuyuClient _client;

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext testContext)
        {
            _client = new FuyuClient("http://localhost:8000", "480892");

            EftDatabase.Load();
            EftServer.Load();
            EftServer.Start();
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
                        Role = WildSpawnType.assault,
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
        public async Task TestClientLogout()
        {
            var data = await _client.GetAsync("/client/game/logout");
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
        public async Task TestClientProductionScavcaseRecipes()
        {
            var data = await _client.GetAsync("/client/hideout/production/scavcase/recipes");
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
        public async Task TestClientLocaleEn()
        {
            var data = await _client.GetAsync("/client/locale/en");
            var result = Encoding.UTF8.GetString(data);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

         [TestMethod]
        public async Task TestClientGetLocalLoot()
        {
            // get request data
            var request = new LocationGetLocalLootRequest()
            {
                locationId = "factory4_day",
                variantId = 1
            };

            // get request body
            var json = Json.Stringify(request);
            var body = Encoding.UTF8.GetBytes(json);

            // get response
            var data = await _client.PostAsync("/client/location/getLocalloot", body);
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
        public async Task TestClientMatchOfflineEnd()
        {
            var data = await _client.GetAsync("/client/match/offline/end");
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