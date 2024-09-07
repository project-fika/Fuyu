using Fuyu.Common.Collections;
using Fuyu.Common.IO;
using Fuyu.Common.Serialization;
using Fuyu.Backend.Core.DTO.Accounts;

namespace Fuyu.Backend.Core
{
    // NOTE: The properties of this class should _NEVER_ be accessed from the
    //       outside. Use CoreOrm instead.
    // -- seionmoya, 2024/09/06

    public static class CoreDatabase
    {
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
                CoreOrm.SetOrAddAccount(account);

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