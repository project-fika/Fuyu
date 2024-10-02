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

        public async Task RouteEvent(ItemEventContext context)
        {
            foreach (var controller in Controllers)
            {
                if (controller.Action == context.Action)
                {
                    Terminal.WriteLine($"Running {controller.GetType().Name}");
                    await controller.Handle(context);
                }
            }
        }
    }
}