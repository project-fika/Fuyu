using System.Diagnostics;
using System.IO;

namespace Fuyu.Platform.Launcher
{
    public class EftProcess
    {
        public static Process Get(string cwd, int accountId, string address)
        {
            // get launch argument
            var token = "-token=" + accountId;
            var config = "-config={\"BackendUrl\":\"" + address + "\",\"Version\":\"live\"}";
            var arguments = $"{token} {config}";

            // get process to create
            return new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    Arguments = arguments,
                    FileName = Path.Combine(cwd, "EscapeFromTarkov.exe"),
                    WorkingDirectory = cwd
                }
            };
        }
    }
}