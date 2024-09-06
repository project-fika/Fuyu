using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fuyu.Common.IO;
using Fuyu.Common.Hashing;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Backend.Common.DTO.Requests;
using Fuyu.Backend.Common.DTO.Responses;
using Fuyu.Backend.Core.DTO.Accounts;

namespace Fuyu.Backend.Core.Services
{
    public static class AccountService
    {
        // TODO:
        // * account login state tracking
        // -- seionmoya, 2024/09/02

        public static int AccountExists(string username, string password)
        {
            var lowerUsername = username.ToLowerInvariant();
            var accounts = CoreOrm.GetAccounts();

            // find account
            var found = new List<Account>();

            foreach (var account in accounts)
            {
                if (account.Username == lowerUsername && account.Password == password)
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
            var accountId = AccountExists(username, password);

            if (accountId == -1)
            {
                // account doesn't exist
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
            // NOTE: MongoId's are used internally, but EFT's launcher uses
            //       a different ID system (hwid+timestamp hash). Instead of
            //       fully mimicking this, I decided to generate a new MongoId
            //       for each login.
            // -- seionmoya, 2024/09/02
            var sessionId = new MongoId(accountId).ToString();
            CoreOrm.AddSession(sessionId, accountId);
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

        public static ERegisterStatus RegisterAccount(string username, string password)
        {
            if (AccountExists(username, password) != -1)
            {
                return ERegisterStatus.AlreadyExists;
            }

            var account = new Account()
            {
                Id = GetNewAccountId(),
                Username = username.ToLowerInvariant(),
                Password = password,
                Games = new Dictionary<string, List<int>>()
                {
                    { "eft",   new List<int>() },
                    { "arena", new List<int>() },
                }
            };

            CoreOrm.AddAccount(account);
            WriteToDisk(account);

            return ERegisterStatus.Success;
        }

        public static ERegisterStatus RegisterGame(string sessionId, string game, string edition)
        {
            var account = CoreOrm.GetAccount(sessionId);

            string address;

            switch (game)
            {
                case "eft":
                    address = "http://localhost:8010";
                    break;

                case "arena":
                    address = "http://localhost:8020";
                    break;

                default:
                    address = string.Empty;
                    break;
            }

            using (var httpClient = new HttpClient(address, sessionId))
            {
                // request game registration on game server
                var request = new FuyuGameRegisterRequest()
                {
                    Username = account.Username,
                    Edition = edition
                };
                var requestJson = Json.Stringify(request);
                var requestBytes = Encoding.UTF8.GetBytes(requestJson);
                var responseBytes = httpClient.Post("/fuyu/game/register", requestBytes);
                var responseJson = Encoding.UTF8.GetString(responseBytes);
                var response = Json.Parse<FuyuGameRegisterResponse>(responseJson);

                // set game account id
                account.Games[game].Add(response.AccountId);
            }

            CoreOrm.SetAccount(account);
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