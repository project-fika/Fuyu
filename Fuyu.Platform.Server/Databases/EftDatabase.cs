using Fuyu.Platform.Common.IO;

namespace Fuyu.Platform.Server.Databases
{
    public static class EftDatabase
    {
        public static readonly LocaleTable Locales;

        static EftDatabase()
        {
            Locales = new LocaleTable();
        }

        public static void Load()
        {
            // set data source
            Resx.SetSource("fuyu", typeof(EftDatabase).Assembly);

            // load tables
            Locales.Load();
        }
    }
}