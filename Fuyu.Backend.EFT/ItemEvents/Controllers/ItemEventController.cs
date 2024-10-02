using Fuyu.Backend.EFT.ItemEvents.Models;
using System.Threading.Tasks;

namespace Fuyu.Backend.EFT.ItemEvents.Controllers
{
    public abstract class ItemEventController<TEvent>(string action) : IItemEventController where TEvent : BaseItemEvent
    {
        public string Action { get; } = action;

        public Task Handle(ItemEventContext context)
        {
            return Handle(context, context.GetData<TEvent>());
        }

        public abstract Task Handle(ItemEventContext context, TEvent request);
    }
}
