using Fuyu.Common.IO;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Backend.BSG.DTO.Responses;
using Fuyu.Backend.EFT.DTO.Responses;

namespace Fuyu.Backend.EFT.Controllers
{
    public class BuildsListController : HttpController
    {
        private readonly ResponseBody<BuildsListResponse> _response;

        public BuildsListController() : base("/client/builds/list")
        {
            var json = Resx.GetText("eft", "database.client.builds.list.json");
            _response = Json.Parse<ResponseBody<BuildsListResponse>>(json);
        }

        public override void Run(HttpContext context)
        {
            SendJson(context, Json.Stringify(_response));
        }
    }
}