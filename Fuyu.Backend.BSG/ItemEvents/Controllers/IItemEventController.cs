using System.Threading.Tasks;

namespace Fuyu.Backend.BSG.ItemEvents.Controllers
{
    public interface IItemEventController
    {
        public string Action { get; }
        public abstract Task RunAsync(ItemEventContext context);
    }
}
