using System.Collections.Generic;
using Fuyu.Common.Collections;
using Fuyu.Common.IO;
using Fuyu.Backend.BSG.DTO.Customization;
using Fuyu.Backend.BSG.DTO.Profiles;
using Fuyu.Backend.BSG.DTO.Responses;
using Fuyu.Backend.EFT.DTO.Responses;
using Fuyu.Common.Serialization;
using Fuyu.Backend.EFT.DTO.Accounts;
using Fuyu.Backend.BSG.DTO.Profiles.Info;

namespace Fuyu.Backend.EFT
{
    // NOTE: The properties of this class should _NEVER_ be accessed from the
    //       outside. Use EftOrm instead.
    // -- seionmoya, 2024/09/04

    public static class EftDatabase
    {
        internal static readonly ThreadList<EftAccount> Accounts;

        internal static readonly ThreadList<EftProfile> Profiles;

        //                                        sessid  aid
        internal static readonly ThreadDictionary<string, int> Sessions;

        //                                        custid  template 
        internal static readonly ThreadDictionary<string, CustomizationTemplate> Customizations;

        //                                        langid             key     value
        internal static readonly ThreadDictionary<string, Dictionary<string, string>> GlobalLocales;

        //                                        langid  name
        internal static readonly ThreadDictionary<string, string> Languages;

        //                                        langid  locale
        internal static readonly ThreadDictionary<string, MenuLocaleResponse> MenuLocales;

        //                                        edition            side         profile
        internal static readonly ThreadDictionary<string, Dictionary<EPlayerSide, Profile>> WipeProfiles;

        // TODO
        internal static readonly ThreadObject<string> AccountCustomization;

        static EftDatabase()
        {
            Accounts = new ThreadList<EftAccount>();
            Profiles = new ThreadList<EftProfile>();
            Sessions = new ThreadDictionary<string, int>();

            Customizations = new ThreadDictionary<string, CustomizationTemplate>();
            GlobalLocales = new ThreadDictionary<string, Dictionary<string, string>>();
            Languages = new ThreadDictionary<string, string>();
            MenuLocales = new ThreadDictionary<string, MenuLocaleResponse>();
            WipeProfiles = new ThreadDictionary<string, Dictionary<EPlayerSide, Profile>>();

            // TODO
            AccountCustomization = new ThreadObject<string>(string.Empty);
        }

        // NOTE: load order is VERY important!
        // -- seionmoya, 2024/09/04
        public static void Load()
        {
            // set data source
            Resx.SetSource("eft", typeof(EftDatabase).Assembly);

            // load accounts
            LoadAccounts();
            LoadProfiles();
            LoadSessions();

            // load locales
            LoadLanguages();
            LoadGlobalLocales();
            LoadMenuLocales();

            // load templates
            LoadCustomizations();
            LoadWipeProfiles();

            // TODO
            LoadUnparsed();
        }

        private static void LoadAccounts()
        {
            // TODO
        }

        private static void LoadProfiles()
        {
            // TODO
        }

        private static void LoadSessions()
        {
            // TODO
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
            var languages = EftOrm.GetLanguages();

            foreach (var languageId in languages.Keys)
            {
                var json = Resx.GetText("eft", $"database.locales.client.locale-{languageId}.json");
                var response = Json.Parse<ResponseBody<Dictionary<string, string>>>(json);

                GlobalLocales.Add(languageId, response.data);
            }
        }

        private static void LoadMenuLocales()
        {
            var languages = EftOrm.GetLanguages();

            foreach (var languageId in languages.Keys)
            {
                var json = Resx.GetText("eft", $"database.locales.client.menu.locale-{languageId}.json");
                var response = Json.Parse<ResponseBody<MenuLocaleResponse>>(json);

                MenuLocales.Add(languageId, response.data);
            }
        }

        private static void LoadWipeProfiles()
        {
            var bearJson = Resx.GetText("eft", "database.profiles.player.unheard-bear.json");
            var usecJson = Resx.GetText("eft", "database.profiles.player.unheard-usec.json");
            var savageJson = Resx.GetText("eft", "database.profiles.player.savage.json");

            var bearProfile = Json.Parse<Profile>(bearJson);
            var usecProfile = Json.Parse<Profile>(usecJson);
            var savageProfile = Json.Parse<Profile>(savageJson);

            WipeProfiles.Add("unheard", new Dictionary<EPlayerSide, Profile>()
            {
                { EPlayerSide.Bear, bearProfile },
                { EPlayerSide.Usec, usecProfile },
                { EPlayerSide.Savage, savageProfile }
            });
        }

        // TODO
        private static void LoadUnparsed()
        {
            AccountCustomization.Set(Resx.GetText("eft", "database.client.account.customization.json"));
        }
    }
}