using Fuyu.Platform.Common.IO;
using Fuyu.Platform.Server.Databases.Fuyu;

namespace Fuyu.Platform.Server.Databases
{
    public static class FuyuDatabase
    {
        public static readonly AccountTable Accounts;

        static FuyuDatabase()
        {
            Accounts = new AccountTable();
        }

        public static void Load()
        {
            // set data source
            Resx.SetSource("fuyu", typeof(FuyuDatabase).Assembly);

            // load tables
            Accounts.Load();
        }
    }
}