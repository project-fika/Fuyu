using System;

namespace Fuyu.Platform.Common.Http
{
    public class ErrorBehaviour : FuyuBehaviour
    {
        public override void Run(FuyuContext context)
        {
            Console.WriteLine($"No service found for {context.GetPath()}");
            Close(context);
        }
    }
}