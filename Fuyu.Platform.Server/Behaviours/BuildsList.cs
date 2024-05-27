using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.IO;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Server.Behaviours
{
    public class BuildsList : FuyuBehaviour
    {
        private readonly ResponseBody<BuildsListResponse> _response;

        public BuildsList()
        {
            var json = Resx.GetText("fuyu", "database.client.builds.list.json");
            _response = Json.Parse<ResponseBody<BuildsListResponse>>(json);
        }

        public override void Run(FuyuContext context)
        {
            SendJson(context, Json.Stringify(_response));
        }
    }
}