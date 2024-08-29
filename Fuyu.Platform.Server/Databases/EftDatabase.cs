using Fuyu.Platform.Common.IO;

namespace Fuyu.Platform.Server.Databases
{
    public static class EftDatabase
    {
        public static void Load()
        {
            // set data source
            Resx.SetSource("fuyu", typeof(EftDatabase).Assembly);
        }
    }
}