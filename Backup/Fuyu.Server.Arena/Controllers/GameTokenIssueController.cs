using Fuyu.Common.IO;
using Fuyu.Common.Networking;

namespace Fuyu.Server.Arena.Controllers
{
    public class GameTokenIssueController : HttpController
    {
        private readonly string _response;

        public GameTokenIssueController() : base("/client/game/token/issue")
        {
            _response = Resx.GetText("eft", "database.client.game.token.issue.json");
        }

        public override void Run(HttpContext context)
        {
            SendJson(context, _response);
        }
    }
}