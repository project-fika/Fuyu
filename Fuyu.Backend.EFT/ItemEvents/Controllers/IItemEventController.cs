using System.Threading.Tasks;

namespace Fuyu.Backend.EFT.ItemEvents.Controllers
{
    public interface IItemEventController
    {
        public string Action { get; }
        public abstract Task RunAsync(ItemEventContext context);
    }
}
