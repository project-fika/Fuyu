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
        // -- seionmoya, 2024/09/02

        public static string LoginAccount(int accountId)
        {
            var sessions = EftOrm.GetSessions();

            foreach (var kvp in sessions)
            {
                if (kvp.Value == accountId)
                {
                    // session already exists
                    return kvp.Key;
                }
            }

            // NOTE: MongoId's are used internally, but EFT's launcher uses
            //       a different ID system (hwid+timestamp hash). Instead of
            //       fully mimicking this, I decided to generate a new MongoId
            //       for each login.
            // -- seionmoya, 2024/09/02
            var sessionId = new MongoId(true).ToString();
            EftOrm.AddSession(sessionId, accountId);
            return sessionId.ToString();
        }

        private static int GetNewAccountId()
        {
            var accounts = EftOrm.GetAccounts();

            // using linq because sorting otherwise takes up too much code
            var sorted = accounts.OrderBy(account => account.Id).ToArray();
            
            // NOTE: I know multi-threading is overkill for most systems, but I
            //       want to keep in mind large server workloads
            // -- seionmoya, 2024/09/02
            var found = new List<int>();

            for (var i = 0; i < sorted.Length; ++i)
            {
                if (sorted[i].Id != i)
                {
                    found.Add(sorted[i].Id);
                }
            }

            if (found.Count != 0)
            {
                // use gap entry
                return found[0];
            }
            else
            {
                // use new entry
                return sorted.Length;
            }
        }

        public static int RegisterAccount()
        {
            var id = GetNewAccountId();
            var account = new EftAccount()
            {
                Id = id,
                Edition = string.Empty,
                PvpId = string.Empty,
                PveId = string.Empty
            };

            EftOrm.AddAccount(account);
            WriteToDisk(account);

            return id;
        }

        public static void WriteToDisk(EftAccount account)
        {
            VFS.WriteTextFile(
                $"./Fuyu/Accounts/EFT{account.Id}.json",
                Json.Stringify(account));
        }
    }
}