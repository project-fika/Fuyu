using System.Linq;
using Fuyu.Common.Hashing;
using Fuyu.Common.IO;
using Fuyu.Common.Serialization;
using Fuyu.Backend.EFT.DTO.Accounts;
using System.Collections.Generic;

namespace Fuyu.Backend.EFT.Services
{
    public static class AccountService
    {
        // TODO:
        // * account login state tracking
        // -- seionmoya, 2024/09/06

        public static string LoginAccount(int accountId)
        {
            if (accountId == -1)
            {
                // account doesn't exist
                return string.Empty;
            }

            // find active account session
            var sessions = EftOrm.GetSessions();

            foreach (var kvp in sessions)
            {
                if (kvp.Value == accountId)
                {
                    // session already exists
                    return kvp.Key;
                }
            }

            // create new account session
            // NOTE: MongoId's are used internally, but EFT's launcher uses
            //       a different ID system (hwid+timestamp hash). Instead of
            //       fully mimicking this, I decided to generate a new MongoId
            //       for each login.
            // -- seionmoya, 2024/09/02
            var sessionId = new MongoId(accountId).ToString();
            EftOrm.SetOrAddSession(sessionId, accountId);
            return sessionId.ToString();
        }

        private static int GetNewAccountId()
        {
            var accounts = EftOrm.GetAccounts();

            // using linq because sorting otherwise takes up too much code
            var sorted = accounts.OrderBy(account => account.Id).ToArray();

            // find all gap entries
            var found = new List<int>();

            for (var i = 0; i < sorted.Length; ++i)
            {
                if (sorted[i].Id != i)
                {
                    found.Add(sorted[i].Id);
                }
            }

            if (found.Count > 0)
            {
                // use first gap entry
                return found[0];
            }
            else
            {
                // use new entry
                return sorted.Length;
            }
        }

        public static int RegisterAccount(string username, string edition)
        {
            var accountId = GetNewAccountId();

            // create profiles
            var pvpId = ProfileService.CreateProfile(accountId);
            var pveId = ProfileService.CreateProfile(accountId);

            // create account   
            var account = new EftAccount()
            {
                Id = accountId,
                Edition = edition,
                Username = username,
                PvpId = pvpId,
                PveId = pveId
            };

            EftOrm.SetOrAddAccount(account);
            WriteToDisk(account);

            return accountId;
        }

        public static void WriteToDisk(EftAccount account)
        {
            VFS.WriteTextFile(
                $"./Fuyu/Accounts/EFT/{account.Id}.json",
                Json.Stringify(account));
        }
    }
}