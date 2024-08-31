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
            Server.AddHttpService<AccountCustomization>();
            Server.AddHttpService<AchievementList>();
            Server.AddHttpService<AchievementStatistic>();
            Server.AddHttpService<BuildsList>();
            Server.AddHttpService<CheckVersion>();
            Server.AddHttpService<Customization>();
            Server.AddHttpService<CustomizationStorage>();
            Server.AddHttpService<FriendList>();
            Server.AddHttpService<FriendRequestListInbox>();
            Server.AddHttpService<FriendRequestListOutbox>();
            Server.AddHttpService<GameBotGenerate>();
            Server.AddHttpService<GameKeepalive>();
            Server.AddHttpService<GameConfig>();
            Server.AddHttpService<GameLogout>();
            Server.AddHttpService<GameMode>();
            Server.AddHttpService<GameProfileCreate>();
            Server.AddHttpService<GameProfileList>();
            Server.AddHttpService<GameProfileNicknameReserved>();
            Server.AddHttpService<GameProfileNicknameValidate>();
            Server.AddHttpService<GameProfileSelect>();
            Server.AddHttpService<GameStart>();
            Server.AddHttpService<GameVersionValidate>();
            Server.AddHttpService<GetMetricsConfig>();
            Server.AddHttpService<Globals>();
            Server.AddHttpService<HandbookTemplates>();
            Server.AddHttpService<HideoutAreas>();
            Server.AddHttpService<HideoutProductionRecipes>();
            Server.AddHttpService<HideoutQteList>();
            Server.AddHttpService<HideoutSettings>();
            Server.AddHttpService<Items>();
            Server.AddHttpService<Languages>();
            Server.AddHttpService<Locale>();
            Server.AddHttpService<LocalGameWeather>();
            Server.AddHttpService<Locations>();
            Server.AddHttpService<MailDialogList>();
            Server.AddHttpService<MatchGroupCurrent>();
            Server.AddHttpService<MatchGroupExitFromMenu>();
            Server.AddHttpService<MatchGroupInviteCancelAll>();
            Server.AddHttpService<MatchLocalEnd>();
            Server.AddHttpService<MatchLocalStart>();
            Server.AddHttpService<MenuLocale>();
            Server.AddHttpService<NotifierChannelCreate>();
            Server.AddHttpService<ProfileSettings>();
            Server.AddHttpService<ProfileStatus>();
            Server.AddHttpService<PutMetrics>();
            Server.AddHttpService<QuestList>();
            Server.AddHttpService<RaidConfiguration>();
            Server.AddHttpService<RepeatableQuestActivityPeriods>();
            Server.AddHttpService<ServerList>();
            Server.AddHttpService<Settings>();
            Server.AddHttpService<Survey>();
            Server.AddHttpService<TraderSettings>();
            Server.AddHttpService<Weather>();
        }

        public static void Start()
        {
            Server.Start();
        }
    }
}