using System.Collections.Generic;
using Fuyu.Platform.Common.Collections;
using Fuyu.Platform.Common.IO;
using Fuyu.Platform.Common.Models.EFT.Customization;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Server.Databases.EFT
{
    public class TemplateTable
    {
        public TemplateTable()
        {
            _customizations = new ThreadDictionary<string, CustomizationTemplate>();
        }

        public void Load()
        {
            LoadCustomizations();
        }

#region Customization
//                                        custid  template 
        private readonly ThreadDictionary<string, CustomizationTemplate> _customizations;

        private void LoadCustomizations()
        {
            var json = Resx.GetText("eft", "database.eft.client.customization.json");
            var response = Json.Parse<ResponseBody<Dictionary<string, CustomizationTemplate>>>(json);

            foreach (var kvp in response.data)
            {
                AddCustomization(kvp.Key, kvp.Value);
            }
        }

        public Dictionary<string, CustomizationTemplate> GetCustomizations()
        {
            return _customizations.ToDictionary();
        }

        public CustomizationTemplate GetCustomization(string customizationId)
        {
            return _customizations.Get(customizationId);
        }

        public void SetCustomization(string customizationId, CustomizationTemplate template)
        {
            _customizations.Set(customizationId, template);
        }

        public void AddCustomization(string customizationId, CustomizationTemplate template)
        {
            _customizations.Add(customizationId, template);
        }

        public void RemoveCustomization(string customizationId)
        {
            _customizations.Remove(customizationId);
        }
#endregion
    }
}