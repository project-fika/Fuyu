using System;

namespace Fuyu.Common.IO
{
    public class Terminal
    {
        public static void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

        public static void WriteLine(object o)
        {
            if (o == null)
            {
                throw new NullReferenceException();
            }

            WriteLine(o.ToString());
        }

        public static void WaitForInput()
        {
            // Console.ReadKey doesn't work in vscode buildin terminal
            Console.In.ReadLine();
        }
    }
}