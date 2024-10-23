using Fuyu.Common.Networking;
using Fuyu.Backend.EFT.Controllers;

namespace Fuyu.Backend.EFT.Servers
{
    public class EftMainServer : HttpServer
    {
        public EftMainServer() : base("eft-main", "http://localhost:8010/")
        {
        }

        public void RegisterServices()
        {
            // Fuyu
            HttpRouter.AddController<FuyuGameLoginController>();
            HttpRouter.AddController<FuyuGameRegisterController>();
            HttpRouter.AddController<FuyuGameWipeProfilesController>();
            // EFT
            HttpRouter.AddController<AccountCustomizationController>();
            HttpRouter.AddController<AchievementListController>();
            HttpRouter.AddController<AchievementStatisticController>();
            HttpRouter.AddController<BuildsListController>();
            HttpRouter.AddController<CheckVersionController>();
            HttpRouter.AddController<CustomizationController>();
            HttpRouter.AddController<CustomizationStorageController>();
            HttpRouter.AddController<FriendListController>();
            HttpRouter.AddController<FriendRequestListInboxController>();
            HttpRouter.AddController<FriendRequestListOutboxController>();
            HttpRouter.AddController<GameBotGenerateController>();
            HttpRouter.AddController<GameKeepaliveController>();
            HttpRouter.AddController<GameConfigController>();
            HttpRouter.AddController<GameLogoutController>();
            HttpRouter.AddController<GameModeController>();
            HttpRouter.AddController<GameProfileCreateController>();
            HttpRouter.AddController<GameProfileItemsMovingController>();
            HttpRouter.AddController<GameProfileListController>();
            HttpRouter.AddController<GameProfileNicknameReservedController>();
            HttpRouter.AddController<GameProfileNicknameValidateController>();
            HttpRouter.AddController<GameProfileSelectController>();
            HttpRouter.AddController<GameStartController>();
            HttpRouter.AddController<GameVersionValidateController>();
            HttpRouter.AddController<GetMetricsConfigController>();
            HttpRouter.AddController<GlobalsController>();
            HttpRouter.AddController<HandbookTemplatesController>();
            HttpRouter.AddController<HideoutAreasController>();
            HttpRouter.AddController<HideoutProductionRecipesController>();
            HttpRouter.AddController<HideoutQteListController>();
            HttpRouter.AddController<HideoutSettingsController>();
            HttpRouter.AddController<ItemsController>();
            HttpRouter.AddController<LanguagesController>();
            HttpRouter.AddController<LocaleController>();
            HttpRouter.AddController<LocalGameWeatherController>();
            HttpRouter.AddController<LocationsController>();
            HttpRouter.AddController<MailDialogListController>();
            HttpRouter.AddController<MatchGroupCurrentController>();
            HttpRouter.AddController<MatchGroupExitFromMenuController>();
            HttpRouter.AddController<MatchGroupInviteCancelAllController>();
            HttpRouter.AddController<MatchLocalEndController>();
            HttpRouter.AddController<MatchLocalStartController>();
            HttpRouter.AddController<MenuLocaleController>();
            HttpRouter.AddController<NotifierChannelCreateController>();
            HttpRouter.AddController<ProfileSettingsController>();
            HttpRouter.AddController<ProfileStatusController>();
            HttpRouter.AddController<PutMetricsController>();
            HttpRouter.AddController<QuestListController>();
            HttpRouter.AddController<RaidConfigurationController>();
            HttpRouter.AddController<RepeatableQuestActivityPeriodsController>();
            HttpRouter.AddController<ServerListController>();
            HttpRouter.AddController<SettingsController>();
            HttpRouter.AddController<SurveyController>();
            HttpRouter.AddController<TraderSettingsController>();
            HttpRouter.AddController<WeatherController>();
        }
    }
}