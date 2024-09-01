using Fuyu.Platform.Common.Networking;
using Fuyu.Platform.Common.IO;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class BuildsList : FuyuHttpBehaviour
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