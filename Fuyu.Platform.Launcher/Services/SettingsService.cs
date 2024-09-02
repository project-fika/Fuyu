using System;

namespace Fuyu.Platform.Launcher.Services
{
    public static class SettingsService
    {
        // server settings
        public static string FuyuAddress;
        public static string EftAddress;
        public static string ArenaAddress;

        // client settings
        public static string EftDirectory;
        public static string ArenaDirectory;

        static SettingsService()
        {
            // server settings
            FuyuAddress = "http://localhost:8000";
            EftAddress = "http://localhost:8001";
            ArenaAddress = "http://localhost:8020";

            // client settings
            EftDirectory = Environment.CurrentDirectory;
            ArenaDirectory = Environment.CurrentDirectory;
        }
    }
}
