using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.IO;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class QuestList : FuyuHttpBehaviour
    {
        private readonly string _response;

        public QuestList() : base("/client/quest/list")
        {
            _response = Resx.GetText("eft", "database.eft.client.quest.list.json");
        }

        public override void Run(FuyuHttpContext context)
        {
            SendJson(context, _response);
        }
    }
}