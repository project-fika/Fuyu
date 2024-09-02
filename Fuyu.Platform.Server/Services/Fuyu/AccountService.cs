using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using Fuyu.Platform.Common.IO;
using Fuyu.Platform.Common.Models.EFT.Common;
using Fuyu.Platform.Common.Models.Fuyu.Accounts;
using Fuyu.Platform.Common.Serialization;
using Fuyu.Platform.Server.Databases;

namespace Fuyu.Platform.Server.Services.Fuyu
{
    public static class AccountService
    {
        // TODO:
        // * account login state tracking
        // -- seionmoya, 2024/09/02

        public static int AccountExists(string username, string password)
        {
            var lowerUsername = username.ToLowerInvariant();
            var accounts = FuyuDatabase.Accounts.GetAccounts();
            var found = new ConcurrentBag<Account>();

            Parallel.ForEach(accounts, account =>
            {
                if (account.Username == lowerUsername && account.Password == password)
                {
                    found.Add(account);
                }
            });

            if (found.Count > 1)
            {
                throw new Exception($"Multiple accounts found with username {username}.");
            }

            if (found.IsEmpty)
            {
                return -1;
            }

            return found.First().Id;
        }

        public static string LoginAccount(string username, string password)
        {
            var accountId = AccountExists(username, password);

            if (accountId == -1)
            {
                return string.Empty;
            }

            var sessions = FuyuDatabase.Accounts.GetSessions();

            foreach (var kvp in sessions)
            {
                if (kvp.Value == accountId)
                {
                    // session already exists
                    return kvp.Key;
                }
            }

            // NOTE: MongoId's are used internally, but EFT's launcher uses
            // a different ID system (hwid+timestamp hash). Instead of
            // fully mimicking this, I decided to generate a new MongoId
            // for each login.
            // -- seionmoya, 2024/09/02
            var sessionId = new MongoId().ToString();
            FuyuDatabase.Accounts.AddSession(sessionId, accountId);
            return sessionId.ToString();
        }

        private static int GetNewAccountId()
        {
            var accounts = FuyuDatabase.Accounts.GetAccounts();

            // using linq because sorting otherwise takes up too much code
            var sorted = accounts.OrderBy(account => account.Id).ToArray();
            
            // NOTE: I know multi-threading is overkill for most systems, but I
            //       want to keep in mind large server workloads
            // -- seionmoya, 2024/09/02
            var found = new ConcurrentBag<int>();

            Parallel.For(0, sorted.Length, i =>
            {
                if (sorted[i].Id != i)
                {
                    found.Add(sorted[i].Id);
                }
            });

            if (!found.IsEmpty)
            {
                // use gap entry
                return found.First();
            }
            else
            {
                // use new entry
                return sorted.Length;
            }
        }

        public static ERegisterStatus RegisterAccount(string username, string password, string edition)
        {
            if (AccountExists(username, password) != -1)
            {
                return ERegisterStatus.AlreadyExists;
            }

            var id = GetNewAccountId();
            var account = new Account()
            {
                Id = id,
                Username = username.ToLowerInvariant(),
                Password = password,
                EftSave = new EftSave()
                {
                    Edition = edition,
                    PvE = new EftProfile()
                    {
                        Savage = default,
                        Pmc = default,
                        Suites = [],
                        ShouldWipe = true
                    },
                    PvP = new EftProfile()
                    {
                        Savage = default,
                        Pmc = default,
                        Suites = [],
                        ShouldWipe = true
                    }
                }
            };

            FuyuDatabase.Accounts.AddAccount(account);
            WriteAccountToDisk(account);

            return ERegisterStatus.Success;
        }

        public static void WriteAccountToDisk(Account account)
        {
            VFS.WriteTextFile(
                $"{FuyuDatabase.Accounts.GetPath()}{account.Id}.json",
                Json.Stringify(account));
        }
    }
}