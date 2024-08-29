using System.Collections.Generic;
using Fuyu.Platform.Common.IO;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Server.Databases.EFT
{
    public class LocaleTable
    {
        static LocaleTable()
        {
            _languagesLock = new object();
            _globalLocalesLock = new object();
            _menuLocalesLock = new object();
        }

        public LocaleTable()
        {
            _languages = new Dictionary<string, string>();
            _globalLocales = new Dictionary<string, Dictionary<string, string>>();
            _menuLocales = new Dictionary<string, MenuLocaleResponse>();
        }

        public void Load()
        {
            LoadLanguages();
            LoadGlobalLocales();
            LoadMenuLocales();
        }

#region Languages
//                         langid  name
        private readonly Dictionary<string, string> _languages;
        private static readonly object _languagesLock;

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
            return _languages;
        }

        public void SetLanguage(string languageId, string name)
        {
            lock (_languagesLock)
            {
                _languages[languageId] = name;
            }
        }

        public void AddLanguage(string languageId, string name)
        {
            lock (_languagesLock)
            {
                _languages.Add(languageId, name);
            }
        }

        public void RemoveLanguage(string languageId)
        {
            lock (_languagesLock)
            {
                _languages.Remove(languageId);
            }
        }
#endregion

#region GlobalLocales
//                                 langid             key     value
        private readonly Dictionary<string, Dictionary<string, string>> _globalLocales;
        private static readonly object _globalLocalesLock;

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

        public Dictionary<string, string> GetGlobalLocale(string languageId)
        {
            return _globalLocales[languageId];
        }

        public void SetGlobalLocale(string languageId, Dictionary<string, string> globalLocale)
        {
            lock (_globalLocalesLock)
            {
                _globalLocales[languageId] = globalLocale;
            }
        }

        public void AddGlobalLocale(string languageId, Dictionary<string, string> globalLocale)
        {
            lock (_globalLocalesLock)
            {
                _globalLocales.Add(languageId, globalLocale);
            }
        }

        public void RemoveGlobalLocale(string languageId)
        {
            lock (_globalLocalesLock)
            {
                _globalLocales.Remove(languageId);
            }
        }
#endregion

#region MenuLocales
//                                 langid  locale
        private readonly Dictionary<string, MenuLocaleResponse> _menuLocales;
        private static readonly object _menuLocalesLock;

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

        public MenuLocaleResponse GetMenuLocale(string languageId)
        {
            return _menuLocales[languageId];
        }

        public void SetMenuLocale(string languageId, MenuLocaleResponse menuLocale)
        {
            lock (_menuLocalesLock)
            {
                _menuLocales[languageId] = menuLocale;
            }
        }

        public void AddMenuLocale(string languageId, MenuLocaleResponse menuLocale)
        {
            lock (_menuLocalesLock)
            {
                _menuLocales.Add(languageId, menuLocale);
            }
        }

        public void RemoveMenuLocale(string languageId)
        {
            lock (_menuLocalesLock)
            {
                _menuLocales.Remove(languageId);
            }
        }
#endregion
    }
}