using Fuyu.Backend.BSG.ItemEvents;
using Fuyu.Backend.BSG.ItemEvents.Controllers;
using Fuyu.Backend.EFT.ItemEvents.Models;
using System.Threading.Tasks;

namespace Fuyu.Backend.EFT.ItemEvents.Controllers
{
    public class CustomizationBuyEventController : ItemEventController<CustomizationBuyItemEvent>
    {
        public CustomizationBuyEventController() : base("CustomizationBuy")
        {
        }

        public override Task RunAsync(ItemEventContext context, CustomizationBuyItemEvent request)
        {
            return Task.CompletedTask;
        }
    }
}
