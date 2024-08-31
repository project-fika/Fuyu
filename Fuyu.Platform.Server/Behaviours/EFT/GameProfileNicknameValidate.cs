using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.Models.EFT.Requests;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class GameProfileNicknameValidate : FuyuBehaviour
    {
        public GameProfileNicknameValidate() : base("/client/game/profile/nickname/validate")
        {
        }

        public override void Run(FuyuContext context)
        {
            var request = context.GetJson<GameProfileNicknameValidateRequest>();

            // TODO: validate nickname usage

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