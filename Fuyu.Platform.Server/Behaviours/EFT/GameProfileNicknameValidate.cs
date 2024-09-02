using Fuyu.Platform.Common.Models.EFT.Requests;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Networking;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class GameProfileNicknameValidate : HttpBehaviour
    {
        public GameProfileNicknameValidate() : base("/client/game/profile/nickname/validate")
        {
        }

        public override void Run(HttpContext context)
        {
            var request = context.GetJson<GameProfileNicknameValidateRequest>();

            // TODO:
            // * validate nickname usage
            // -- seionmoya, 2024/08/28

            var response = new ResponseBody<GameProfileNicknameValidateResponse>()
            {
                data = new GameProfileNicknameValidateResponse()
                {
                    status = "ok"
                }
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}