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
        internal static readonly ThreadObject<string> AchievementList;
        internal static readonly ThreadObject<string> AchievementStatistic;
        internal static readonly ThreadObject<string> Globals;
        internal static readonly ThreadObject<string> Handbook;
        internal static readonly ThreadObject<string> HideoutAreas;
        internal static readonly ThreadObject<string> HideoutProductionRecipes;
        internal static readonly ThreadObject<string> HideoutQteList;
        internal static readonly ThreadObject<string> HideoutSettings;
        internal static readonly ThreadObject<string> Items;
        internal static readonly ThreadObject<string> LocalWeather;
        internal static readonly ThreadObject<string> Locations;
        internal static readonly ThreadObject<string> Quests;
        internal static readonly ThreadObject<string> Settings;
        internal static readonly ThreadObject<string> Traders;
        internal static readonly ThreadObject<string> Weather;

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
            AchievementList = new ThreadObject<string>(string.Empty);
            AchievementStatistic = new ThreadObject<string>(string.Empty);
            Globals = new ThreadObject<string>(string.Empty);

            Handbook = new ThreadObject<string>(string.Empty);
            HideoutAreas = new ThreadObject<string>(string.Empty);
            HideoutProductionRecipes = new ThreadObject<string>(string.Empty);
            HideoutQteList = new ThreadObject<string>(string.Empty);
            HideoutSettings = new ThreadObject<string>(string.Empty);
            Items = new ThreadObject<string>(string.Empty);
            LocalWeather = new ThreadObject<string>(string.Empty);
            Locations = new ThreadObject<string>(string.Empty);
            Quests = new ThreadObject<string>(string.Empty);
            Settings = new ThreadObject<string>(string.Empty);
            Traders = new ThreadObject<string>(string.Empty);
            Weather = new ThreadObject<string>(string.Empty);
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

            WipeProfiles.Add("unheard", new Dictionary<EPlayerSide, Profile>()
            {
                { EPlayerSide.Bear,     Json.Parse<Profile>(bearJson)   },
                { EPlayerSide.Usec,     Json.Parse<Profile>(usecJson)   },
                { EPlayerSide.Savage,   Json.Parse<Profile>(savageJson) }
            });
        }

        // TODO
        private static void LoadUnparsed()
        {
            AccountCustomization.Set(Resx.GetText("eft", "database.client.account.customization.json"));
            AchievementList.Set(Resx.GetText("eft", "database.client.achievement.list.json"));
            AchievementStatistic.Set(Resx.GetText("eft", "database.client.achievement.statistic.json"));
            Globals.Set(Resx.GetText("eft", "database.client.globals.json"));
            Handbook.Set(Resx.GetText("eft", "database.client.handbook.templates.json"));
            HideoutAreas.Set(Resx.GetText("eft", "database.client.hideout.areas.json"));
            HideoutProductionRecipes.Set(Resx.GetText("eft", "database.client.hideout.production.recipes.json"));
            HideoutQteList.Set(Resx.GetText("eft", "database.client.hideout.qte.list.json"));
            HideoutSettings.Set(Resx.GetText("eft", "database.client.hideout.settings.json"));
            Items.Set(Resx.GetText("eft", "database.client.items.json"));
            LocalWeather.Set(Resx.GetText("eft", "database.client.localGame.weather.json"));
            Locations.Set(Resx.GetText("eft", "database.client.locations.json"));
            Quests.Set(Resx.GetText("eft", "database.client.quest.list.json"));
            Settings.Set(Resx.GetText("eft", "database.client.settings.json"));
            Traders.Set(Resx.GetText("eft", "database.client.trading.api.traderSettings.json"));
            Weather.Set(Resx.GetText("eft", "database.client.weather.json"));
        }
    }
}