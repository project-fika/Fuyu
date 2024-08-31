using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class ProfileSettings : FuyuBehaviour
    {
        public ProfileSettings() : base("/client/profile/settings")
        {
        }

        public override void Run(FuyuContext context)
        {
            var response = new ResponseBody<bool>()
            {
                data = true
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}