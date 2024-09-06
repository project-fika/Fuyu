using Fuyu.Common.Collections;
using Fuyu.Common.IO;
using Fuyu.Common.Serialization;
using Fuyu.Backend.Core.DTO.Accounts;

namespace Fuyu.Backend.Core
{
    public static class CoreDatabase
    {
        // NOTE: rationale for using List<Account> over Dictionary<int, Account>
        //       is the accountId is already stored in the Account so having to
        //       sync both the Account.Id and dictionary is a bit annoying, and 
        //       a dictionary loops over all keys anyways (unless using
        //       TryGetValue() but that uses 'out' which I want to avoid).
        // -- seionmoya, 2024/09/02
        internal static readonly ThreadList<Account> Accounts;

        //                                sessid  aid
        internal static readonly ThreadDictionary<string, int> Sessions;

        static CoreDatabase()
        {
            Accounts = new ThreadList<Account>();
            Sessions = new ThreadDictionary<string, int>();
        }

        public static void Load()
        {
            LoadAccounts();
            LoadSessions();
        }

        private static void LoadAccounts()
        {
            var path = "./Fuyu/Accounts/Core/";

            if (!VFS.DirectoryExists(path))
            {
                VFS.CreateDirectory(path);
            }

            var files = VFS.GetFiles(path);

            foreach (var filepath in files)
            {
                var json = VFS.ReadTextFile(filepath);
                var account = Json.Parse<Account>(json);
                CoreOrm.AddAccount(account);

                Terminal.WriteLine($"Loaded fuyu account {account.Id}");
            }
        }

        private static void LoadSessions()
        {
            // intentionally empty
            // sessions are created when users are logged in successfully
            // -- seionmoya, 2024/09/02
        }
    }
}