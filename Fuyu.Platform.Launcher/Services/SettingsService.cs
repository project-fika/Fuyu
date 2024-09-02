using System;

namespace Fuyu.Platform.Launcher.Services
{
    public static class SettingsService
    {
        public static string ClientDirectory;
        public static string FuyuAddress;
        public static string EftAddress;

        static SettingsService()
        {
            ClientDirectory = Environment.CurrentDirectory;
            FuyuAddress = "http://localhost:8000";
            EftAddress = "http://localhost:8001";
        }
    }
}
