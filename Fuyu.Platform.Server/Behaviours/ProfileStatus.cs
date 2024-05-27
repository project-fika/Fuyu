using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.IO;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Server.Behaviours
{
    public class ProfileStatus : FuyuBehaviour
    {
        private readonly ResponseBody<ProfileStatusResponse> _response;

        public ProfileStatus()
        {
            var json = Resx.GetText("fuyu", "database.client.profile.status.json");
            _response = Json.Parse<ResponseBody<ProfileStatusResponse>>(json);
        }

        public override void Run(FuyuContext context)
        {
            SendJson(context, Json.Stringify(_response));
        }
    }
}