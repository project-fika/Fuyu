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
        public static EftProfile GetProfile(string profileId)
        {
            // TODO
            return default;
        }

        public static void SetProfile(EftProfile profile)
        {
            // TODO
        }
#endregion

#region Account
        public static List<EftAccount> GetAccounts()
        {
            return EftDatabase.Accounts.ToList();
        }

        public static EftAccount GetAccount(int accountId)
        {
            return EftDatabase.Accounts.Get(accountId);
        }

        public static EftAccount GetAccount(string sessionId)
        {
            var accountId = GetSession(sessionId);
            return EftDatabase.Accounts.Get(accountId);
        }

        public static void SetAccount(EftAccount account)
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
        }

        public static void AddAccount(EftAccount account)
        {
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

        public static void SetSession(string sessionId, int accountId)
        {
            EftDatabase.Sessions.Set(sessionId, accountId);
        }

        public static void AddSession(string sessionId, int accountId)
        {
            EftDatabase.Sessions.Add(sessionId, accountId);
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

#region Wipe profiles
        public static Dictionary<string, Dictionary<EPlayerSide, Profile>> GetWipeProfiles()
        {
            return EftDatabase.WipeProfiles.ToDictionary();
        }

        public static Dictionary<EPlayerSide, Profile> GetWipeProfile(string edition)
        {
            return EftDatabase.WipeProfiles.Get(edition);
        }

        public static void SetWipeProfile(string edition, Dictionary<EPlayerSide, Profile> profiles)
        {
            EftDatabase.WipeProfiles.Set(edition, profiles);
        }

        public static void AddWipeProfile(string edition, Dictionary<EPlayerSide, Profile> profiles)
        {
            EftDatabase.WipeProfiles.Add(edition, profiles);
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
#endregion
    }
}