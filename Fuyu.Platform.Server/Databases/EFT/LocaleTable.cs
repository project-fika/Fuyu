using System.Collections.Generic;
using Fuyu.Platform.Common.Collections;
using Fuyu.Platform.Common.IO;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Server.Databases.EFT
{
    public class LocaleTable
    {
        public LocaleTable()
        {
            _languages = new ThreadDictionary<string, string>();
            _globalLocales = new ThreadDictionary<string, Dictionary<string, string>>();
            _menuLocales = new ThreadDictionary<string, MenuLocaleResponse>();
        }

        public void Load()
        {
            LoadLanguages();
            LoadGlobalLocales();
            LoadMenuLocales();
        }

#region Languages
//                                       langid  name
        private readonly ThreadDictionary<string, string> _languages;

        private void LoadLanguages()
        {
            var json = Resx.GetText("eft", $"database.eft.locales.client.languages.json");
            var response = Json.Parse<ResponseBody<Dictionary<string, string>>>(json);

            foreach (var kvp in response.data)
            {
                AddLanguage(kvp.Key, kvp.Value);
            }
        }

        public Dictionary<string, string> GetLanguages()
        {
            return _languages.ToDictionary();
        }

        public string GetLanguage(string languageId)
        {
            return _languages.Get(languageId);
        }

        public void SetLanguage(string languageId, string name)
        {
            _languages.Set(languageId, name);
        }

        public void AddLanguage(string languageId, string name)
        {
            _languages.Add(languageId, name);
        }

        public void RemoveLanguage(string languageId)
        {
            _languages.Remove(languageId);
        }
#endregion

#region GlobalLocales
//                                        langid             key     value
        private readonly ThreadDictionary<string, Dictionary<string, string>> _globalLocales;

        private void LoadGlobalLocales()
        {
            var languages = GetLanguages();

            foreach (var languageId in languages.Keys)
            {
                var json = Resx.GetText("eft", $"database.eft.locales.client.locale-{languageId}.json");
                var response = Json.Parse<ResponseBody<Dictionary<string, string>>>(json);

                AddGlobalLocale(languageId, response.data);
            }
        }

        public Dictionary<string, Dictionary<string, string>> GetGlobalLocales()
        {
            return _globalLocales.ToDictionary();
        }

        public Dictionary<string, string> GetGlobalLocale(string languageId)
        {
            return _globalLocales.Get(languageId);
        }

        public void SetGlobalLocale(string languageId, Dictionary<string, string> globalLocale)
        {
            _globalLocales.Set(languageId, globalLocale);
        }

        public void AddGlobalLocale(string languageId, Dictionary<string, string> globalLocale)
        {
            _globalLocales.Add(languageId, globalLocale);
        }

        public void RemoveGlobalLocale(string languageId)
        {
            _globalLocales.Remove(languageId);
        }
#endregion

#region MenuLocales
//                                        langid  locale
        private readonly ThreadDictionary<string, MenuLocaleResponse> _menuLocales;

        private void LoadMenuLocales()
        {
            var languages = GetLanguages();

            foreach (var languageId in languages.Keys)
            {
                var json = Resx.GetText("eft", $"database.eft.locales.client.menu.locale-{languageId}.json");
                var response = Json.Parse<ResponseBody<MenuLocaleResponse>>(json);

                AddMenuLocale(languageId, response.data);
            }
        }

        public Dictionary<string, MenuLocaleResponse> GetMenuLocales()
        {
            return _menuLocales.ToDictionary();
        }

        public MenuLocaleResponse GetMenuLocale(string languageId)
        {
            return _menuLocales.Get(languageId);
        }

        public void SetMenuLocale(string languageId, MenuLocaleResponse menuLocale)
        {
            _menuLocales.Set(languageId, menuLocale);
        }

        public void AddMenuLocale(string languageId, MenuLocaleResponse menuLocale)
        {
            _menuLocales.Add(languageId, menuLocale);
        }

        public void RemoveMenuLocale(string languageId)
        {
            _menuLocales.Remove(languageId);
        }
#endregion
    }
}