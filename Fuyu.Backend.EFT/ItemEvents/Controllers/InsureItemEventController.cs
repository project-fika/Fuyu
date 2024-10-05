using System.Threading.Tasks;
using Fuyu.Backend.BSG.ItemEvents;
using Fuyu.Backend.BSG.ItemEvents.Controllers;
using Fuyu.Backend.EFT.ItemEvents.Models;

namespace Fuyu.Backend.EFT.ItemEvents.Controllers
{
	public class InsureEventController : ItemEventController<InsureItemEvent>
	{
		public InsureEventController() : base("Insure")
		{
		}

		public override Task RunAsync(ItemEventContext context, InsureItemEvent request)
		{
			return Task.CompletedTask;
		}
	}
}
