using System;
using Fuyu.Platform.Launcher;

namespace Fuyu.Launcher
{
    public class Program
    {
        static void Main()
        {
            Console.Title = "Fuyu.Launcher";

            var cwd = Environment.CurrentDirectory;
            var accountId = 480892;
            var address = "http://localhost:8000";

            using (var process = EftProcess.Get(cwd, accountId, address))
            {
                process.Start();
            }
        }
    }
}