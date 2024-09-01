using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.IO;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class BuildsList : FuyuBehaviour
    {
        private readonly ResponseBody<BuildsListResponse> _response;

        public BuildsList() : base("/client/builds/list")
        {
            var json = Resx.GetText("eft", "database.eft.client.builds.list.json");
            _response = Json.Parse<ResponseBody<BuildsListResponse>>(json);
        }

        public override void Run(FuyuHttpContext context)
        {
            SendJson(context, Json.Stringify(_response));
        }
    }
}