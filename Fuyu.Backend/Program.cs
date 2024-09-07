using Fuyu.Common.IO;
using Fuyu.Backend.Core;
using Fuyu.Backend.Core.Servers;
using Fuyu.Backend.EFT;
using Fuyu.Backend.EFT.Servers;

namespace Fuyu.Backend
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