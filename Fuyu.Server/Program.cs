using Fuyu.Platform.Common.IO;
using Fuyu.Platform.Server.Servers;
using Fuyu.Platform.Server.Databases;

namespace Fuyu.Server
{
    public class Program
    {
        static void Main()
        {
            EftDatabase.Load();
            EftServer.Load();
            EftServer.Start();

            Terminal.WaitForInput();
        }
    }
}