using Fuyu.Platform.Common.IO;
using Fuyu.Platform.Server;
using Fuyu.Platform.Server.Databases;

namespace Fuyu.Server
{
    public class Program
    {
        static void Main()
        {
            FuyuDatabase.Load();
            EftDatabase.Load();

            ServerManager.LoadAll();
            ServerManager.StartAll();

            Terminal.WaitForInput();
        }
    }
}