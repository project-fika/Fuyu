using Fuyu.Backend.BSG.ItemEvents.Models;
using System.Threading.Tasks;

namespace Fuyu.Backend.BSG.ItemEvents.Controllers
{
    public abstract class ItemEventController<TEvent> : IItemEventController where TEvent : BaseItemEvent
    {
        public string Action { get; private set; }

        public ItemEventController(string action)
		{
			Action = action;
		}

		public virtual bool IsMatch(ItemEventContext context)
		{
            return context.Action == Action;
		}

		public Task RunAsync(ItemEventContext context)
        {
            return RunAsync(context, context.GetData<TEvent>());
        }

        public abstract Task RunAsync(ItemEventContext context, TEvent request);
    }
}
