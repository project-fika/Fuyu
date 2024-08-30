using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Server.Behaviours.EFT;

namespace Fuyu.Platform.Server.Servers
{
    public class EftServer
    {
        public static readonly FuyuServer Server;

        static EftServer()
        {
            Server = new FuyuServer("eft", "http://localhost:8000");
        }

        public static void Load()
        {
            Server.AddHttpService<AccountCustomization>("/client/account/customization");
            Server.AddHttpService<AchievementList>("/client/achievement/list");
            Server.AddHttpService<AchievementStatistic>("/client/achievement/statistic");
            Server.AddHttpService<BuildsList>("/client/builds/list");
            Server.AddHttpService<CheckVersion>("/client/checkVersion");
            Server.AddHttpService<Customization>("/client/customization");
            Server.AddHttpService<CustomizationStorage>("/client/trading/customization/storage");
            Server.AddHttpService<FriendList>("/client/friend/list");
            Server.AddHttpService<FriendRequestListInbox>("/client/friend/request/list/inbox");
            Server.AddHttpService<FriendRequestListOutbox>("/client/friend/request/list/outbox");
            Server.AddHttpService<GameBotGenerate>("/client/game/bot/generate");
            Server.AddHttpService<GameConfig>("/client/game/config");
            Server.AddHttpService<GameConfig>("/client/game/keepalive");
            Server.AddHttpService<GameLogout>("/client/game/logout");
            Server.AddHttpService<GameMode>("/client/game/mode");
            Server.AddHttpService<GameProfileCreate>("/client/game/profile/create");
            Server.AddHttpService<GameProfileList>("/client/game/profile/list");
            Server.AddHttpService<GameProfileNicknameReserved>("/client/game/profile/nickname/reserved");
            Server.AddHttpService<GameProfileNicknameValidate>("/client/game/profile/nickname/validate");
            Server.AddHttpService<GameProfileSelect>("/client/game/profile/select");
            Server.AddHttpService<GameStart>("/client/game/start");
            Server.AddHttpService<GameVersionValidate>("/client/game/version/validate");
            Server.AddHttpService<GetMetricsConfig>("/client/getMetricsConfig");
            Server.AddHttpService<Globals>("/client/globals");
            Server.AddHttpService<HandbookTemplates>("/client/handbook/templates");
            Server.AddHttpService<HideoutAreas>("/client/hideout/areas");
            Server.AddHttpService<HideoutProductionRecipes>("/client/hideout/production/recipes");
            Server.AddHttpService<HideoutQteList>("/client/hideout/qte/list");
            Server.AddHttpService<HideoutSettings>("/client/hideout/settings");
            Server.AddHttpService<Items>("/client/items");
            Server.AddHttpService<Languages>("/client/languages");
            /*Server.AddHttpService<LocaleCh>("/client/locale/ch");
            Server.AddHttpService<LocaleCz>("/client/locale/cz");
            Server.AddHttpService<LocaleEn>("/client/locale/en");
            Server.AddHttpService<LocaleEs>("/client/locale/es");
            Server.AddHttpService<LocaleEsMx>("/client/locale/es-mx");
            Server.AddHttpService<LocaleFr>("/client/locale/fr");
            Server.AddHttpService<LocaleGe>("/client/locale/ge");
            Server.AddHttpService<LocaleHu>("/client/locale/hu");
            Server.AddHttpService<LocaleIt>("/client/locale/it");
            Server.AddHttpService<LocaleJp>("/client/locale/jp");
            Server.AddHttpService<LocaleKr>("/client/locale/kr");
            Server.AddHttpService<LocalePo>("/client/locale/po");
            Server.AddHttpService<LocalePl>("/client/locale/pl");
            Server.AddHttpService<LocaleRo>("/client/locale/ro");
            Server.AddHttpService<LocaleRu>("/client/locale/ru");
            Server.AddHttpService<LocaleSk>("/client/locale/sk");
            Server.AddHttpService<LocaleTu>("/client/locale/tu");*/
            Server.AddHttpService<Locale>("/client/locale/{locale}");
            Server.AddHttpService<LocalGameWeather>("/client/localGame/weather");
            Server.AddHttpService<Locations>("/client/locations");
            Server.AddHttpService<MailDialogList>("/client/mail/dialog/list");
            Server.AddHttpService<MatchGroupCurrent>("/client/match/group/current");
            Server.AddHttpService<MatchGroupExitFromMenu>("/client/match/group/exit_from_menu");
            Server.AddHttpService<MatchGroupInviteCancelAll>("/client/match/group/invite/cancel-all");
            Server.AddHttpService<MatchLocalEnd>("/client/match/local/end");
            Server.AddHttpService<MatchLocalStart>("/client/match/local/start");
            /*Server.AddHttpService<MenuLocaleCh>("/client/menu/locale/ch");
            Server.AddHttpService<MenuLocaleCz>("/client/menu/locale/cz");
            Server.AddHttpService<MenuLocaleEn>("/client/menu/locale/en");
            Server.AddHttpService<MenuLocaleEs>("/client/menu/locale/es");
            Server.AddHttpService<MenuLocaleEsMx>("/client/menu/locale/es-mx");
            Server.AddHttpService<MenuLocaleFr>("/client/menu/locale/fr");
            Server.AddHttpService<MenuLocaleGe>("/client/menu/locale/ge");
            Server.AddHttpService<MenuLocaleHu>("/client/menu/locale/hu");
            Server.AddHttpService<MenuLocaleIt>("/client/menu/locale/it");
            Server.AddHttpService<MenuLocaleJp>("/client/menu/locale/jp");
            Server.AddHttpService<MenuLocaleKr>("/client/menu/locale/kr");
            Server.AddHttpService<MenuLocalePo>("/client/menu/locale/po");
            Server.AddHttpService<MenuLocalePl>("/client/menu/locale/pl");
            Server.AddHttpService<MenuLocaleRo>("/client/menu/locale/ro");
            Server.AddHttpService<MenuLocaleRu>("/client/menu/locale/ru");
            Server.AddHttpService<MenuLocaleSk>("/client/menu/locale/sk");
            Server.AddHttpService<MenuLocaleTu>("/client/menu/locale/tu");*/
            Server.AddHttpService<MenuLocale>("/client/menu/locale/{locale}");
            Server.AddHttpService<NotifierChannelCreate>("/client/notifier/channel/create");
            Server.AddHttpService<ProfileSettings>("/client/profile/settings");
            Server.AddHttpService<ProfileStatus>("/client/profile/status");
            Server.AddHttpService<ProfileStatus>("/client/putMetrics");
            Server.AddHttpService<QuestList>("/client/quest/list");
            Server.AddHttpService<RaidConfiguration>("/client/raid/configuration");
            Server.AddHttpService<RepeatableQuestActivityPeriods>("/client/repeatalbeQuests/activityPeriods");
            Server.AddHttpService<ServerList>("/client/server/list");
            Server.AddHttpService<Settings>("/client/settings");
            Server.AddHttpService<Survey>("/client/survey");
            Server.AddHttpService<TraderSettings>("/client/trading/api/traderSettings");
            Server.AddHttpService<Weather>("/client/weather");
        }

        public static void Start()
        {
            Server.Start();
        }
    }
}