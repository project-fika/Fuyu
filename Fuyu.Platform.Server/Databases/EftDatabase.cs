using Fuyu.Platform.Common.IO;
using Fuyu.Platform.Server.Databases.Tables;

namespace Fuyu.Platform.Server.Databases
{
    public static class EftDatabase
    {
        public static readonly LocationTable Location;

        static EftDatabase()
        {
            Location = new LocationTable();
        }

        public static void Load()
        {
            // set data source
            Resx.SetSource("fuyu", typeof(EftDatabase).Assembly);

            // load tables
            Location.Load();
        }
    }
}