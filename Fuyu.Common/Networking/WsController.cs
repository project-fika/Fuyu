using System;
using System.Threading.Tasks;

namespace Fuyu.Common.Networking
{
    public abstract class WsController : Controller
    {
        public WsController(string path) : base(path)
        {
        }

        public abstract Task RunAsync(WsContext context);

        public virtual Task OnConnectAsync(WsContext context)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnCloseAsync(WsContext context)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnTextAsync(WsContext context, string text)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnBinaryAsync(WsContext context, byte[] binary)
        {
            return Task.CompletedTask;
        }

        public async Task InitializeAsync(WsContext context)
        {
            context.OnCloseAsync = OnCloseAsync;
            context.OnTextAsync = OnTextAsync;
            context.OnBinaryAsync = OnBinaryAsync;
            await OnConnectAsync(context);
        }
    }
}