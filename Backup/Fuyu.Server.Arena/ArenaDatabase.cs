using System.Collections.Generic;
using Fuyu.Common.Collections;
using Fuyu.Common.IO;
using Fuyu.Server.BSG.DTO.Customization;
using Fuyu.Server.BSG.DTO.Responses;
using Fuyu.Common.Serialization;

namespace Fuyu.Server.EFT
{
    // NOTE: The properties of this class should _NEVER_ be accessed from the
    //       outside. Use ArenaOrm instead.
    // -- seionmoya, 2024/09/04

    internal static class ArenaDatabase
    {
        //                                        custid  template 
        internal static readonly ThreadDictionary<string, CustomizationTemplate> Customizations;

        //                                        langid             key     value
        internal static readonly ThreadDictionary<string, Dictionary<string, string>> GlobalLocales;

        //                                        langid  name
        internal static readonly ThreadDictionary<string, string> _languages;

        //                                        langid  locale
        internal static readonly ThreadDictionary<string, MenuLocaleResponse> MenuLocales;

        static ArenaDatabase()
        {
            Customizations = new ThreadDictionary<string, CustomizationTemplate>();
            GlobalLocales = new ThreadDictionary<string, Dictionary<string, string>>();
            Languages = new ThreadDictionary<string, string>();
            MenuLocales = new ThreadDictionary<string, MenuLocaleResponse>();
        }

        // NOTE: load order is VERY important!
        // -- seionmoya, 2024/09/04
        public static void Load()
        {
            // set data source
            Resx.SetSource("eft", typeof(EftDatabase).Assembly);

            // load locales
            LoadLanguages();
            LoadGlobalLocales();
            LoadMenuLocales();

            // load templates
            LoadCustomizations();
        }

        private static void LoadCustomizations()
        {
            var json = Resx.GetText("eft", "database.client.customization.json");
            var response = Json.Parse<ResponseBody<Dictionary<string, CustomizationTemplate>>>(json);

            foreach (var kvp in response.data)
            {
                Customizations.Add(kvp.Key, kvp.Value);
            }
        }

        private static void LoadLanguages()
        {
            var json = Resx.GetText("eft", $"database.locales.client.languages.json");
            var response = Json.Parse<ResponseBody<Dictionary<string, string>>>(json);

            foreach (var kvp in response.data)
            {
                Languages.Add(kvp.Key, kvp.Value);
            }
        }

        private static void LoadGlobalLocales()
        {
            var languages = GetLanguages();

            foreach (var languageId in languages.Keys)
            {
                var json = Resx.GetText("eft", $"database.locales.client.locale-{languageId}.json");
                var response = Json.Parse<ResponseBody<Dictionary<string, string>>>(json);

                GlobalLocales.Add(languageId, response.data);
            }
        }

        private static void LoadMenuLocales()
        {
            var languages = GetLanguages();

            foreach (var languageId in languages.Keys)
            {
                var json = Resx.GetText("eft", $"database.locales.client.menu.locale-{languageId}.json");
                var response = Json.Parse<ResponseBody<MenuLocaleResponse>>(json);

                MenuLocales.Add(languageId, response.data);
            }
        }
    }
}