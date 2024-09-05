using Fuyu.Common.Networking;
using Fuyu.Backend.EFT.Controllers;

namespace Fuyu.Backend.EFT.Servers
{
    public class EftMainServer : HttpServer
    {
        public EftMainServer() : base("eft-main", "http://localhost:8010")
        {
        }

        public override void RegisterServices()
        {
            AddHttpController<AccountCustomizationController>();
            AddHttpController<AchievementListController>();
            AddHttpController<AchievementStatisticController>();
            AddHttpController<BuildsListController>();
            AddHttpController<CheckVersionController>();
            AddHttpController<CustomizationController>();
            AddHttpController<CustomizationStorageController>();
            AddHttpController<FriendListController>();
            AddHttpController<FriendRequestListInboxController>();
            AddHttpController<FriendRequestListOutboxController>();
            AddHttpController<GameBotGenerateController>();
            AddHttpController<GameKeepaliveController>();
            AddHttpController<GameConfigController>();
            AddHttpController<GameLogoutController>();
            AddHttpController<GameModeController>();
            AddHttpController<GameProfileCreateController>();
            AddHttpController<GameProfileListController>();
            AddHttpController<GameProfileNicknameReservedController>();
            AddHttpController<GameProfileNicknameValidateController>();
            AddHttpController<GameProfileSelectController>();
            AddHttpController<GameStartController>();
            AddHttpController<GameVersionValidateController>();
            AddHttpController<GetMetricsConfigController>();
            AddHttpController<GlobalsController>();
            AddHttpController<HandbookTemplatesController>();
            AddHttpController<HideoutAreasController>();
            AddHttpController<HideoutProductionRecipesController>();
            AddHttpController<HideoutQteListController>();
            AddHttpController<HideoutSettingsController>();
            AddHttpController<ItemsController>();
            AddHttpController<LanguagesController>();
            AddHttpController<LocaleController>();
            AddHttpController<LocalGameWeatherController>();
            AddHttpController<LocationsController>();
            AddHttpController<MailDialogListController>();
            AddHttpController<MatchGroupCurrentController>();
            AddHttpController<MatchGroupExitFromMenuController>();
            AddHttpController<MatchGroupInviteCancelAllController>();
            AddHttpController<MatchLocalEndController>();
            AddHttpController<MatchLocalStartController>();
            AddHttpController<MenuLocaleController>();
            AddHttpController<NotifierChannelCreateController>();
            AddHttpController<ProfileSettingsController>();
            AddHttpController<ProfileStatusController>();
            AddHttpController<PutMetricsController>();
            AddHttpController<QuestListController>();
            AddHttpController<RaidConfigurationController>();
            AddHttpController<RepeatableQuestActivityPeriodsController>();
            AddHttpController<ServerListController>();
            AddHttpController<SettingsController>();
            AddHttpController<SurveyController>();
            AddHttpController<TraderSettingsController>();
            AddHttpController<WeatherController>();
        }
    }
}