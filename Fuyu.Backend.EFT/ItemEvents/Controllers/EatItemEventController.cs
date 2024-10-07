using System.Threading.Tasks;
using Fuyu.Backend.BSG.ItemEvents;
using Fuyu.Backend.BSG.ItemEvents.Controllers;
using Fuyu.Backend.EFT.DTO.Items;
using Fuyu.Backend.EFT.ItemEvents.Models;
using Fuyu.Common.IO;

namespace Fuyu.Backend.EFT.ItemEvents.Controllers
{
	public class EatItemEventController : ItemEventController<EatItemEvent>
	{
		public EatItemEventController() : base("Eat")
		{
		}

		// This method only finds the item, as well as the index. Actually consuming/deleting the item needs to be done.
		public override Task RunAsync(ItemEventContext context, EatItemEvent request)
		{
			var account = EftOrm.GetAccount(context.SessionId);
			var profile = EftOrm.GetProfile(account.PveId);
			var index = 0;
			ItemInstance item = null;

			foreach (var _item in profile.Pmc.Inventory.items)
			{
				if (_item._id == request.Item)
				{
					item = _item;
					break;
				}

				index++;
			}

			if (item == null)
			{
				Terminal.WriteLine($"Failed to find item {request.Item}");
				return Task.CompletedTask;
			}

			return Task.CompletedTask;
		}
	}
}
