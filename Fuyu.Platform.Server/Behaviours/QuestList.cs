using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.IO;

namespace Fuyu.Platform.Server.Behaviours
{
    public class QuestList : FuyuBehaviour
    {
        private readonly string _response;

        public QuestList()
        {
            _response = Resx.GetText("fuyu", "database.client.quest.list.json");
        }

        public override void Run(FuyuContext context)
        {
            SendJson(context, _response);
        }
    }
}