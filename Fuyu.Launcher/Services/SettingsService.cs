using System;

namespace Fuyu.Launcher.Services
{
    public static class SettingsService
    {
        public static string ServerDirectory;
        public static string ClientDirectory;
        public static string Address;

        static SettingsService()
        {
            ServerDirectory = Environment.CurrentDirectory;
            ClientDirectory = Environment.CurrentDirectory;
            Address = "http://localhost:8000";
        }
    }
}
