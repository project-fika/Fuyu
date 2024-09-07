using System.Collections.Generic;
using Fuyu.Backend.BSG.DTO.Customization;
using Fuyu.Backend.BSG.DTO.Profiles;
using Fuyu.Backend.BSG.DTO.Profiles.Info;
using Fuyu.Backend.EFT.DTO.Accounts;
using Fuyu.Backend.EFT.DTO.Responses;

namespace Fuyu.Backend.EFT
{
    public static class EftOrm
    {
#region Profile
        public static List<EftProfile> GetProfiles()
        {
            return EftDatabase.Profiles.ToList();
        }

        public static EftProfile GetProfile(string profileId)
        {
            var profiles = GetProfiles();

            for (var i = 0; i < profiles.Count; ++i)
            {
                if (profiles[i].Pmc._id == profileId)
                {
                    return profiles[i];
                }
            }

            return null;
        }

        public static void SetOrAddProfile(EftProfile profile)
        {
            var profiles = GetProfiles();

            for (var i = 0; i < profiles.Count; ++i)
            {
                if (profiles[i].Pmc._id == profile.Pmc._id)
                {
                    EftDatabase.Profiles.Set(i, profile);
                    return;
                }
            }

            EftDatabase.Profiles.Add(profile);
        }

        public static void RemoveProfile(EftProfile profile)
        {
            var profiles = GetProfiles();

            for (var i = 0; i < profiles.Count; ++i)
            {
                if (profiles[i].Pmc._id == profile.Pmc._id)
                {
                    EftDatabase.Profiles.RemoveAt(i);
                    return;
                }
            }
        }
#endregion

#region Account
        public static List<EftAccount> GetAccounts()
        {
            return EftDatabase.Accounts.ToList();
        }

        public static EftAccount GetAccount(int accountId)
        {
            var accounts = GetAccounts();

            for (var i = 0; i < accounts.Count; ++i)
            {
                if (accounts[i].Id == accountId)
                {
                    return accounts[i];
                }
            }

            return null;
        }

        public static EftAccount GetAccount(string sessionId)
        {
            var accountId = GetSession(sessionId);
            return GetAccount(accountId);
        }

        public static void SetOrAddAccount(EftAccount account)
        {
            var accounts = GetAccounts();

            for (var i = 0; i < accounts.Count; ++i)
            {
                if (accounts[i].Id == account.Id)
                {
                    EftDatabase.Accounts.Set(i, account);
                    return;
                }
            }

            EftDatabase.Accounts.Add(account);
        }

        public static void RemoveAccount(EftAccount account)
        {
            var accounts = GetAccounts();

            for (var i = 0; i < accounts.Count; ++i)
            {
                if (accounts[i].Id == account.Id)
                {
                    EftDatabase.Accounts.RemoveAt(i);
                    return;
                }
            }
        }
#endregion

#region Session
        public static Dictionary<string, int> GetSessions()
        {
            return EftDatabase.Sessions.ToDictionary();
        }

        public static int GetSession(string sessionId)
        {
            return EftDatabase.Sessions.Get(sessionId);
        }

        public static void SetOrAddSession(string sessionId, int accountId)
        {
            if (EftDatabase.Sessions.ContainsKey(sessionId))
            {
                EftDatabase.Sessions.Set(sessionId, accountId);
            }
            else
            {
                EftDatabase.Sessions.Add(sessionId, accountId);
            }
        }

        public static void RemoveSession(string sessionId)
        {
            EftDatabase.Sessions.Remove(sessionId);
        }
#endregion

#region Customization
        public static Dictionary<string, CustomizationTemplate> GetCustomizations()
        {
            return EftDatabase.Customizations.ToDictionary();
        }

        public static CustomizationTemplate GetCustomization(string customizationId)
        {
            return EftDatabase.Customizations.Get(customizationId);
        }

        public static void SetOrAddCustomization(string customizationId, CustomizationTemplate template)
        {
            if (EftDatabase.Customizations.ContainsKey(customizationId))
            {
                EftDatabase.Customizations.Set(customizationId, template);
            }
            else
            {
                EftDatabase.Customizations.Add(customizationId, template);
            }
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

        public static void SetOrAddLanguage(string languageId, string name)
        {
            if (EftDatabase.Languages.ContainsKey(languageId))
            {
                EftDatabase.Languages.Set(languageId, name);
            }
            else
            {
                EftDatabase.Languages.Add(languageId, name);
            }
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

        public static void SetOrAddGlobalLocale(string languageId, Dictionary<string, string> globalLocale)
        {
            if (EftDatabase.GlobalLocales.ContainsKey(languageId))
            {
                EftDatabase.GlobalLocales.Set(languageId, globalLocale);
            }
            else
            {
                EftDatabase.GlobalLocales.Add(languageId, globalLocale);
            }
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

        public static void SetOrAddMenuLocale(string languageId, MenuLocaleResponse menuLocale)
        {
            if (EftDatabase.MenuLocales.ContainsKey(languageId))
            {
                EftDatabase.MenuLocales.Set(languageId, menuLocale);
            }
            else
            {
                EftDatabase.MenuLocales.Add(languageId, menuLocale);
            }
        }

        public static void RemoveMenuLocale(string languageId)
        {
            EftDatabase.MenuLocales.Remove(languageId);
        }
#endregion

#region Wipe profiles
        public static Dictionary<string, Dictionary<EPlayerSide, Profile>> GetWipeProfiles()
        {
            return EftDatabase.WipeProfiles.ToDictionary();
        }

        public static Dictionary<EPlayerSide, Profile> GetWipeProfile(string edition)
        {
            return EftDatabase.WipeProfiles.Get(edition);
        }

        public static void SetOrAddWipeProfile(string edition, Dictionary<EPlayerSide, Profile> profiles)
        {
            if (EftDatabase.WipeProfiles.ContainsKey(edition))
            {
                EftDatabase.WipeProfiles.Set(edition, profiles);
            }
            else
            {
                EftDatabase.WipeProfiles.Add(edition, profiles);
            }
        }

        public static void RemoveWipeProfile(string edition)
        {
            EftDatabase.WipeProfiles.Remove(edition);
        }
#endregion

#region Unparsed
        public static string GetAccountCustomization()
        {
            return EftDatabase.AccountCustomization.Get();
        }

        public static string GetAchievementList()
        {
            return EftDatabase.AchievementList.Get();
        }

        public static string GetAchievementStatistic()
        {
            return EftDatabase.AchievementStatistic.Get();
        }

        public static string GetGlobals()
        {
            return EftDatabase.Globals.Get();
        }

        public static string GetHandbook()
        {
            return EftDatabase.Handbook.Get();
        }

        public static string GetHideoutAreas()
        {
            return EftDatabase.HideoutAreas.Get();
        }

        public static string GetHideoutProductionRecipes()
        {
            return EftDatabase.HideoutProductionRecipes.Get();
        }

        public static string GetHideoutQteList()
        {
            return EftDatabase.HideoutQteList.Get();
        }

        public static string GetHideoutSettings()
        {
            return EftDatabase.HideoutSettings.Get();
        }

        public static string GetItems()
        {
            return EftDatabase.Items.Get();
        }

        public static string GetLocalWeather()
        {
            return EftDatabase.LocalWeather.Get();
        }

        public static string GetLocations()
        {
            return EftDatabase.Locations.Get();
        }

        public static string GetQuest()
        {
            return EftDatabase.Quests.Get();
        }

        public static string GetSettings()
        {
            return EftDatabase.Settings.Get();
        }

        public static string GetTraders()
        {
            return EftDatabase.Traders.Get();
        }

        public static string GetWeather()
        {
            return EftDatabase.Weather.Get();
        }
#endregion
    }
}