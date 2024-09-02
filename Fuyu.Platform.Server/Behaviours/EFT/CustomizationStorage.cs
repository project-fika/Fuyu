using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Networking;
using Fuyu.Platform.Common.Serialization;
using Fuyu.Platform.Server.Databases;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class CustomizationStorage : HttpBehaviour
    {
        public CustomizationStorage() : base("/client/trading/customization/storage")
        {
        }

        public override void Run(HttpContext context)
        {
            var sessionId = context.GetSessionId();
            var account = FuyuDatabase.Accounts.GetAccount(sessionId);

            // TODO:
            // * PVP-PVE state detection
            // -- seionmoya, 2024/08/28
            var response = new ResponseBody<CustomizationStorageResponse>()
            {
                data = new CustomizationStorageResponse()
                {
                    _id = account.EftSave.PvE.Pmc._id,
                    suites = account.EftSave.PvE.Suites
                }
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}