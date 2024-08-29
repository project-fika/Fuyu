using System.Collections.Generic;
using Fuyu.Platform.Common.IO;
using Fuyu.Platform.Common.Models.EFT.Customization;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Server.Databases.EFT
{
    public class TemplateTable
    {
        static TemplateTable()
        {
            _customizationsLock = new object();
        }

        public TemplateTable()
        {
            _customizations = new Dictionary<string, CustomizationTemplate>();
        }

        public void Load()
        {
            LoadCustomizations();
        }

#region Customization
//                                  custid  template 
        private readonly Dictionary<string, CustomizationTemplate> _customizations;
        private static readonly object _customizationsLock;

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
            return _customizations;
        }

        public CustomizationTemplate GetCustomization(string customizationId)
        {
            return _customizations[customizationId];
        }

        public void SetCustomization(string customizationId, CustomizationTemplate template)
        {
            lock (_customizationsLock)
            {
                _customizations[customizationId] = template;
            }
        }

        public void AddCustomization(string customizationId, CustomizationTemplate template)
        {
            lock (_customizationsLock)
            {
                _customizations.Add(customizationId, template);
            }
        }

        public void RemoveCustomization(string customizationId)
        {
            lock (_customizationsLock)
            {
                _customizations.Remove(customizationId);
            }
        }
#endregion
    }
}