using Fuyu.Platform.Common.IO;
using Fuyu.Platform.Common.Networking;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class QuestList : HttpBehaviour
    {
        private readonly string _response;

        public QuestList() : base("/client/quest/list")
        {
            _response = Resx.GetText("eft", "database.eft.client.quest.list.json");
        }

        public override void Run(HttpContext context)
        {
            SendJson(context, _response);
        }
    }
}