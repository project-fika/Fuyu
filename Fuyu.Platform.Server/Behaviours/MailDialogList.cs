using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.IO;

namespace Fuyu.Platform.Server.Behaviours
{
    public class MailDialogList : FuyuBehaviour
    {
        private readonly string _response;

        public MailDialogList()
        {
            _response = Resx.GetText("fuyu", "database.client.mail.dialog.list.json");
        }

        public override void Run(FuyuContext context)
        {
            SendJson(context, _response);
        }
    }
}