using Fuyu.Backend.EFT.DTO.Items;
using Fuyu.Backend.EFT.ItemEvents.Models;
using Fuyu.Common.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace Fuyu.Backend.EFT.ItemEvents.Controllers
{
    public class ApplyInventoryChangesItemEventController : ItemEventController<ApplyInventoryChangesEvent>
    {
        public ApplyInventoryChangesItemEventController() : base("ApplyInventoryChanges")
        {
        }

        public override Task Handle(ItemEventContext context, ApplyInventoryChangesEvent request)
        {
            var account = EftOrm.GetAccount(context.SessionId);
            var profile = EftOrm.GetProfile(account.PveId);
            var profileItems = new ThreadDictionary<string, ItemInstance>(profile.Pmc.Inventory.items.ToDictionary(i => i._id, i => i));
            Parallel.ForEach(request.ChangedItems, changedItem =>
            {
                if (profileItems.TryGet(changedItem.Id, out var item))
                {
                    item.slotId = changedItem.Slot;
                    item.location = changedItem.Location;
                }
            });

            return Task.CompletedTask;
        }
    }
}
