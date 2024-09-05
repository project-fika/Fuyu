using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fuyu.Server.Arena;
using Fuyu.Server.Arena.Servers;
using Fuyu.Server.Arena.Services;

namespace Fuyu.Tests.Server.Arena.EndToEnd
{
    [TestClass]
    public class BackendTest
    {
        private static HttpClient _arenaMainClient;

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext testContext)
        {
            // setup databases
            ArenaDatabase.Load();

            // create request clients
            _arenaMainClient = new HttpClient("http://localhost:8020");
        }
    }
}