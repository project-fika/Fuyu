using Fuyu.Platform.Common.IO;
using Fuyu.Platform.Server.Databases.EFT;

namespace Fuyu.Platform.Server.Databases
{
    public static class EftDatabase
    {
        public static readonly LocaleTable Locales;
        public static readonly TemplateTable Templates;

        static EftDatabase()
        {
            Locales = new LocaleTable();
            Templates = new TemplateTable();
        }

        public static void Load()
        {
            // set data source
            Resx.SetSource("eft", typeof(EftDatabase).Assembly);

            // load tables
            Locales.Load();
            Templates.Load();
        }
    }
}