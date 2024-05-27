using System;
using Fuyu.Platform.Server;
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

            // Console.ReadKey doesn't work in vscode buildin terminal
            Console.In.ReadLine();
        }
    }
}