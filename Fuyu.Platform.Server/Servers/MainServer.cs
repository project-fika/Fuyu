using Fuyu.Platform.Common.Networking;
using Fuyu.Platform.Server.Behaviours.EFT;

namespace Fuyu.Platform.Server.Servers
{
    public class EftServer : ServerCore
    {
        public EftServer() : base("eft-main", "http://localhost:8000")
        {
        }

        public override void RegisterServices()
        {
            AddHttpBehaviour<AccountCustomization>();
            AddHttpBehaviour<AchievementList>();
            AddHttpBehaviour<AchievementStatistic>();
            AddHttpBehaviour<BuildsList>();
            AddHttpBehaviour<CheckVersion>();
            AddHttpBehaviour<Customization>();
            AddHttpBehaviour<CustomizationStorage>();
            AddHttpBehaviour<FriendList>();
            AddHttpBehaviour<FriendRequestListInbox>();
            AddHttpBehaviour<FriendRequestListOutbox>();
            AddHttpBehaviour<GameBotGenerate>();
            AddHttpBehaviour<GameKeepalive>();
            AddHttpBehaviour<GameConfig>();
            AddHttpBehaviour<GameLogout>();
            AddHttpBehaviour<GameMode>();
            AddHttpBehaviour<GameProfileCreate>();
            AddHttpBehaviour<GameProfileList>();
            AddHttpBehaviour<GameProfileNicknameReserved>();
            AddHttpBehaviour<GameProfileNicknameValidate>();
            AddHttpBehaviour<GameProfileSelect>();
            AddHttpBehaviour<GameStart>();
            AddHttpBehaviour<GameVersionValidate>();
            AddHttpBehaviour<GetMetricsConfig>();
            AddHttpBehaviour<Globals>();
            AddHttpBehaviour<HandbookTemplates>();
            AddHttpBehaviour<HideoutAreas>();
            AddHttpBehaviour<HideoutProductionRecipes>();
            AddHttpBehaviour<HideoutQteList>();
            AddHttpBehaviour<HideoutSettings>();
            AddHttpBehaviour<Items>();
            AddHttpBehaviour<Languages>();
            AddHttpBehaviour<Locale>();
            AddHttpBehaviour<LocalGameWeather>();
            AddHttpBehaviour<Locations>();
            AddHttpBehaviour<MailDialogList>();
            AddHttpBehaviour<MatchGroupCurrent>();
            AddHttpBehaviour<MatchGroupExitFromMenu>();
            AddHttpBehaviour<MatchGroupInviteCancelAll>();
            AddHttpBehaviour<MatchLocalEnd>();
            AddHttpBehaviour<MatchLocalStart>();
            AddHttpBehaviour<MenuLocale>();
            AddHttpBehaviour<NotifierChannelCreate>();
            AddHttpBehaviour<ProfileSettings>();
            AddHttpBehaviour<ProfileStatus>();
            AddHttpBehaviour<PutMetrics>();
            AddHttpBehaviour<QuestList>();
            AddHttpBehaviour<RaidConfiguration>();
            AddHttpBehaviour<RepeatableQuestActivityPeriods>();
            AddHttpBehaviour<ServerList>();
            AddHttpBehaviour<Settings>();
            AddHttpBehaviour<Survey>();
            AddHttpBehaviour<TraderSettings>();
            AddHttpBehaviour<Weather>();
        }
    }
}