using System.Collections.Generic;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Backend.BSG.DTO.Customization;
using Fuyu.Backend.BSG.DTO.Responses;

namespace Fuyu.Backend.EFT.Controllers
{
    public class CustomizationController : HttpController
    {
        public CustomizationController() : base("/client/customization")
        {
        }

        public override void Run(HttpContext context)
        {
            var customizations = EftOrm.GetCustomizations();
            var response = new ResponseBody<Dictionary<string, CustomizationTemplate>>()
            {
                data = customizations
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}