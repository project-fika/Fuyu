using Fuyu.Backend.EFT.ItemEvents.Controllers;
using Fuyu.Common.IO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fuyu.Backend.EFT.ItemEvents
{
    public class ItemEventRouter
    {
        public List<IItemEventController> Controllers { get; } = [];

        public void AddController<T>() where T : IItemEventController, new()
        {
            var controller = new T();
            Controllers.Add(controller);
        }

        public async Task<bool> RouteEvent(ItemEventContext context)
        {
            bool handled = false;
            foreach (var controller in Controllers)
            {
                if (controller.Action == context.Action)
                {
                    handled = true;
                    Terminal.WriteLine($"Running {controller.GetType().Name}");
                    await controller.Handle(context);
                }
            }

            return handled;
        }
    }
}