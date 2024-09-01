using System.Collections.Generic;
using Fuyu.Platform.Common.Networking;
using Fuyu.Platform.Server.Servers;

namespace Fuyu.Platform.Server
{
    public static class ServerManager
    {
        private static readonly List<ServerCore> _servers;

        static ServerManager()
        {
            _servers = [
                new EftServer()
            ];
        }

        public static void LoadAll()
        {
            foreach (var server in _servers)
            {
                server.RegisterServices();
            }
        }

        public static void StartAll()
        {
            foreach (var server in _servers)
            {
                server.Start();
            }
        }
    }
}