using Fuyu.Common.IO;
using Fuyu.Server.Core;
using Fuyu.Server.Core.Servers;
using Fuyu.Server.EFT;
using Fuyu.Server.EFT.Servers;

namespace Fuyu.Server
{
    public class Program
    {
        static void Main()
        {
            CoreDatabase.Load();
            EftDatabase.Load();

            var coreServer = new CoreServer();
            coreServer.RegisterServices();
            coreServer.Start();

            var eftMainServer = new EftMainServer();
            eftMainServer.RegisterServices();
            eftMainServer.Start();

            Terminal.WaitForInput();
        }
    }
}