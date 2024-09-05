using Fuyu.Common.Networking;

namespace Fuyu.Backend.EFT.Controllers
{
    public class QuestListController : HttpController
    {
        public QuestListController() : base("/client/quest/list")
        {
        }

        public override void Run(HttpContext context)
        {
            SendJson(context, EftOrm.GetQuest());
        }
    }
}