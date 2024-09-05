using System.Collections.Generic;
using Fuyu.Server.BSG.DTO.Customization;
using Fuyu.Server.Arena.DTO.Responses;

namespace Fuyu.Server.Arena
{
    public static class ArenaOrm
    {
#region Customization
        public static Dictionary<string, CustomizationTemplate> GetCustomizations()
        {
            return EftDatabase.Customizations.ToDictionary();
        }

        public static CustomizationTemplate GetCustomization(string customizationId)
        {
            return EftDatabase.Customizations.Get(customizationId);
        }

        public static void SetCustomization(string customizationId, CustomizationTemplate template)
        {
            EftDatabase.Customizations.Set(customizationId, template);
        }

        public static void AddCustomization(string customizationId, CustomizationTemplate template)
        {
            EftDatabase.Customizations.Add(customizationId, template);
        }

        public static void RemoveCustomization(string customizationId)
        {
            EftDatabase.Customizations.Remove(customizationId);
        }
#endregion

#region Languages
        public static Dictionary<string, string> GetLanguages()
        {
            return EftDatabase.Languages.ToDictionary();
        }

        public static string GetLanguage(string languageId)
        {
            return EftDatabase.Languages.Get(languageId);
        }

        public static void SetLanguage(string languageId, string name)
        {
            EftDatabase.Languages.Set(languageId, name);
        }

        public static void AddLanguage(string languageId, string name)
        {
            EftDatabase.Languages.Add(languageId, name);
        }

        public static void RemoveLanguage(string languageId)
        {
            EftDatabase.Languages.Remove(languageId);
        }
#endregion

#region GlobalLocales
        public static Dictionary<string, Dictionary<string, string>> GetGlobalLocales()
        {
            return EftDatabase.GlobalLocales.ToDictionary();
        }

        public static Dictionary<string, string> GetGlobalLocale(string languageId)
        {
            return EftDatabase.GlobalLocales.Get(languageId);
        }

        public static void SetGlobalLocale(string languageId, Dictionary<string, string> globalLocale)
        {
            EftDatabase.GlobalLocales.Set(languageId, globalLocale);
        }

        public static void AddGlobalLocale(string languageId, Dictionary<string, string> globalLocale)
        {
            EftDatabase.GlobalLocales.Add(languageId, globalLocale);
        }

        public static void RemoveGlobalLocale(string languageId)
        {
            EftDatabase.GlobalLocales.Remove(languageId);
        }
#endregion

#region MenuLocales
        public static Dictionary<string, MenuLocaleResponse> GetMenuLocales()
        {
            return EftDatabase.MenuLocales.ToDictionary();
        }

        public static MenuLocaleResponse GetMenuLocale(string languageId)
        {
            return EftDatabase.MenuLocales.Get(languageId);
        }

        public static void SetMenuLocale(string languageId, MenuLocaleResponse menuLocale)
        {
            EftDatabase.MenuLocales.Set(languageId, menuLocale);
        }

        public static void AddMenuLocale(string languageId, MenuLocaleResponse menuLocale)
        {
            EftDatabase.MenuLocales.Add(languageId, menuLocale);
        }

        public static void RemoveMenuLocale(string languageId)
        {
            EftDatabase.MenuLocales.Remove(languageId);
        }
#endregion
    }
}