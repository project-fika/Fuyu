using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.IO;
using Fuyu.Platform.Common.Models.EFT.Profiles;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class GameProfileList : FuyuBehaviour
    {
        private readonly ResponseBody<Profile[]> _response;

        public GameProfileList()
        {
            var json = Resx.GetText("eft", "database.eft.client.game.profile.list.json")
                // Dirty fix: BSG notes empty trader info as [] (incorrect) instead of {} (correct)
                .Replace("\"TradersInfo\":[]", "\"TradersInfo\":{}");

            _response = Json.Parse<ResponseBody<Profile[]>>(json);
        }

        public override void Run(FuyuContext context)
        {
            SendJson(context, Json.Stringify(_response));
        }
    }
}