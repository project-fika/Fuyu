using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fuyu.Server.Core;
using Fuyu.Server.Core.Servers;
using Fuyu.Common.Networking;

namespace Fuyu.Tests.Server.Core.EndToEnd
{
    [TestClass]
    public class BackendTest
    {
        private static HttpClient _coreClient;

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext testContext)
        {
            // setup databases
            CoreDatabase.Load();

            // setup server
            _ = new CoreServer();

            // create request clients
            _coreClient = new HttpClient("http://localhost:8000");
        }
    }
}