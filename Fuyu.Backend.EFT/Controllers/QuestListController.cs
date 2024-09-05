using Fuyu.Common.IO;
using Fuyu.Common.Networking;

namespace Fuyu.Backend.EFT.Controllers
{
    public class QuestListController : HttpController
    {
        private readonly string _response;

        public QuestListController() : base("/client/quest/list")
        {
            _response = Resx.GetText("eft", "database.client.quest.list.json");
        }

        public override void Run(HttpContext context)
        {
            SendJson(context, _response);
        }
    }
}