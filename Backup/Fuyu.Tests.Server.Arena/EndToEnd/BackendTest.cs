using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fuyu.Backend.Arena;
using Fuyu.Backend.Arena.Servers;
using Fuyu.Backend.Arena.Services;

namespace Fuyu.Tests.Backend.Arena.EndToEnd
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
            _arenaMainClient = new EftHttpClient("http://localhost:8020");
        }
    }
}