using System.Collections.Generic;
using System.Linq;
using Fuyu.Common.IO;
using Fuyu.Common.Hashing;
using Fuyu.Common.Serialization;
using Fuyu.Backend.Core.DTO.Accounts;

namespace Fuyu.Backend.Core.Services
{
    public static class AccountService
    {
        // TODO:
        // * account login state tracking
        // -- seionmoya, 2024/09/02

        public static int AccountExists(string username)
        {
            var lowerUsername = username.ToLowerInvariant();
            var accounts = CoreOrm.GetAccounts();

            // find account
            var found = new List<Account>();

            foreach (var account in accounts)
            {
                if (account.Username == lowerUsername)
                {
                    found.Add(account);
                }
            };

            if (found.Count == 0)
            {
                // no account
                return -1;
            }
            else
            {
                // account exists
                return found[0].Id;
            }
        }

        public static string LoginAccount(string username, string password)
        {
            // find account
            var accountId = AccountExists(username);

            if (accountId == -1)
            {
                // account doesn't exist
                return string.Empty;
            }

            // validate password
            var account = CoreOrm.GetAccount(accountId);

            if (account.Password != password)
            {
                // password is wrong
                return string.Empty;
            }

            // find active account session
            var sessions = CoreOrm.GetSessions();

            foreach (var kvp in sessions)
            {
                if (kvp.Value == accountId)
                {
                    // session already exists
                    return kvp.Key;
                }
            }

            // create new account session
            // NOTE: Instead fully mimicking EFT's id (hwid+timestamp hash), I
            //       decided to generate a new MongoId for each login.
            // -- seionmoya, 2024/09/02
            var sessionId = new MongoId(accountId).ToString();
            CoreOrm.SetOrAddSession(sessionId, accountId);
            return sessionId.ToString();
        }

        private static int GetNewAccountId()
        {
            var accounts = CoreOrm.GetAccounts();

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

        // TODO:
        // * store max username length, min/max password length, security requirements in config
        // * validate username characters (only alphabetical, numbers)
        // * validate password characters (only alphabetical, numbers, some special characters)
        // -- seionmoya, 2024/09/08
        public static ERegisterStatus RegisterAccount(string username, string password)
        {
            if (AccountExists(username) != -1)
            {
                return ERegisterStatus.AlreadyExists;
            }

            if (username == string.Empty)
            {
                return ERegisterStatus.UsernameEmpty;
            }

            if (username.Length > 15)
            {
                return ERegisterStatus.UsernameTooLong;
            }

            if (password == string.Empty)
            {
                return ERegisterStatus.PasswordEmpty;
            }

            if (password.Length < 8)
            {
                return ERegisterStatus.PasswordTooShort;
            }

            if (password.Length > 32)
            {
                return ERegisterStatus.PasswordTooLong;
            }

            var hashedPassword = Sha256.Generate(password);
            var account = new Account()
            {
                Id = GetNewAccountId(),
                Username = username.ToLowerInvariant(),
                Password = hashedPassword,
                Games = new Dictionary<string, int?>
                {
                    { "eft",    null },
                    { "arena",  null }
                }
            };

            CoreOrm.SetOrAddAccount(account);
            WriteToDisk(account);

            return ERegisterStatus.Success;
        }

        public static ERegisterStatus RegisterGame(string sessionId, string game, string edition)
        {
            var account = CoreOrm.GetAccount(sessionId);

            // find existing game
            if (account.Games.ContainsKey(game) && account.Games[game].HasValue)
            {
                return ERegisterStatus.AlreadyExists;
            }

            // register game
            var accountId = RequestService.RegisterGame(game, account.Username, edition);
            account.Games[game] = accountId;

            // store result
            CoreOrm.SetOrAddAccount(account);
            WriteToDisk(account);

            return ERegisterStatus.Success;
        }

        public static void WriteToDisk(Account account)
        {
            VFS.WriteTextFile(
                $"./Fuyu/Accounts/Core/{account.Id}.json",
                Json.Stringify(account));
        }
    }
}