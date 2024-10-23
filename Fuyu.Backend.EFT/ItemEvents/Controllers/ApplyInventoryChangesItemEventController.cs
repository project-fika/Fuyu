using Fuyu.Backend.BSG.ItemEvents;
using Fuyu.Backend.EFT.DTO.Items;
using Fuyu.Backend.BSG.ItemEvents.Controllers;
using Fuyu.Backend.EFT.ItemEvents.Models;
using Fuyu.Common.Collections;
using System.Linq;
using System.Threading.Tasks;
using Fuyu.Common.Hashing;

namespace Fuyu.Backend.EFT.ItemEvents.Controllers
{
    public class ApplyInventoryChangesItemEventController : ItemEventController<ApplyInventoryChangesEvent>
    {
        public ApplyInventoryChangesItemEventController() : base("ApplyInventoryChanges")
        {
        }

        public override Task RunAsync(ItemEventContext context, ApplyInventoryChangesEvent request)
        {
            var account = EftOrm.GetAccount(context.SessionId);
            var profile = EftOrm.GetProfile(account.PveId);
            var profileItems = new ThreadDictionary<MongoId, ItemInstance>(profile.Pmc.Inventory.items.ToDictionary(i => i._id, i => i));

            Parallel.ForEach(request.ChangedItems, changedItem =>
            {
                if (profileItems.TryGet(changedItem._id, out var item))
                {
                    item.slotId = changedItem.slotId;
                    item.location = changedItem.location;
                    item.parentId = changedItem.parentId;
                }
            });

            return Task.CompletedTask;
        }
    }
}
