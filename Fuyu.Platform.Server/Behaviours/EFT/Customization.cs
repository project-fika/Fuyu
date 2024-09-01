using System.Collections.Generic;
using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.Models.EFT.Customization;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Serialization;
using Fuyu.Platform.Server.Databases;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class Customization : FuyuBehaviour
    {
        public Customization() : base("/client/customization")
        {
        }

        public override void Run(FuyuHttpContext context)
        {
            var customizations = EftDatabase.Templates.GetCustomizations();
            var response = new ResponseBody<Dictionary<string, CustomizationTemplate>>()
            {
                data = customizations
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}