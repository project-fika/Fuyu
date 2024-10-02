using Fuyu.Backend.EFT.ItemEvents.Models;
using Fuyu.Common.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Fuyu.Backend.EFT.ItemEvents.Controllers
{
    public class MoveItemEventController : ItemEventController<MoveItemEvent>
    {
        public MoveItemEventController() : base("Move")
        {
        }

        public override Task Handle(ItemEventContext context, MoveItemEvent request)
        {
            var account = EftOrm.GetAccount(context.SessionId);
            var profile = EftOrm.GetProfile(account.PveId);
            var item = profile.Pmc.Inventory.items.FirstOrDefault(i => i._id == request.Item);
            if (item is not null)
            {
                item.location = request.To.Location;
                Terminal.WriteLine($"{request.Item} moved to {request.To.Location}");
            }
            else
            {
                Terminal.WriteLine($"Failed to find {request.Item} in inventory");
            }

            return Task.CompletedTask;
        }
    }
}
