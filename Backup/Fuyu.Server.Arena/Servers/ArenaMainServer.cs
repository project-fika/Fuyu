using Fuyu.Common.Networking;
using Fuyu.Server.Arena.Controllers;

namespace Fuyu.Platform.Server.Servers
{
    public class ArenaMainServer : HttpServer
    {
        public ArenaMainServer() : base("arena-main", "http://localhost:8020")
        {
        }

        public override void RegisterServices()
        {
            AddHttpController<ArenaServerListController>();
            AddHttpController<FriendListController>();
            AddHttpController<FriendRequestListInboxController>();
            AddHttpController<FriendRequestListOutboxController>();
            AddHttpController<GameConfigurationController>();
            AddHttpController<GameKeepaliveController>();
            AddHttpController<GameStartController>();
            AddHttpController<GameTokenIssueController>();
            AddHttpController<GameVersionValidateController>();
            AddHttpController<MatchGroupCurrentController>();
            AddHttpController<MatchGroupInviteCancelAllController>();
            AddHttpController<MenuLocaleController>();
            AddHttpController<NotifierChannelCreateController>();
            AddHttpController<ProfileStatusController>();
        }
    }
}