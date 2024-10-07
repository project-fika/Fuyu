using Fuyu.Common.Networking;

namespace Fuyu.Backend.BSG.ItemEvents.Controllers
{
    public interface IItemEventController : IRouterController<ItemEventContext>
    {
        public string Action { get; }
    }
}
