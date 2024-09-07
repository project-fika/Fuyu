using System.Diagnostics;
using System.IO;

namespace Fuyu.Launcher.Core.Services
{
    public class ProcessService
    {
        private static string GetLaunchArguments(string sessionId, string address)
        {
            var token = $"-token={sessionId}";
            var config = "-config={\"BackendUrl\":\"" + address + "\",\"Version\":\"live\"}";
            var arguments = $"{token} {config}";
            return arguments;
        }

        public static Process StartEft(string cwd, string sessionId, string address)
        {
            return new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    Arguments = GetLaunchArguments(sessionId, address),
                    FileName = Path.Combine(cwd, "EscapeFromTarkov.exe"),
                    WorkingDirectory = cwd
                }
            };
        }

        public static Process StartArena(string cwd, string sessionId, string address)
        {
            return new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    Arguments = GetLaunchArguments(sessionId, address),
                    FileName = Path.Combine(cwd, "EscapeFromTarkovArena.exe"),
                    WorkingDirectory = cwd
                }
            };
        }
    }
}
