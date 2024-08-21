using Fuyu.Platform.Common.IO;

namespace Fuyu.Platform.Common.Http
{
    public class ErrorBehaviour : FuyuBehaviour
    {
        public override void Run(FuyuContext context)
        {
            Terminal.WriteLine($"No service found for {context.GetPath()}");
            Close(context);
        }
    }
}