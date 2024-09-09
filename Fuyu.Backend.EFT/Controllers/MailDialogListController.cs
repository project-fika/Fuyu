using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Backend.BSG.DTO.Responses;

namespace Fuyu.Backend.EFT.Controllers
{
    public class MailDialogListController : HttpController
    {
        public MailDialogListController() : base("/client/mail/dialog/list")
        {
        }

        public override void Run(HttpContext context)
        {
            var response = new ResponseBody<object[]>
            {
                data = []
            };

            context.SendJson(Json.Stringify(response));
        }
    }
}