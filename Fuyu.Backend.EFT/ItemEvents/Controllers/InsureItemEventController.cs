using Fuyu.Backend.EFT.DTO.Responses;
using Fuyu.Backend.EFT.ItemEvents.Models;
using Fuyu.Common.Networking;
using System.Threading.Tasks;

namespace Fuyu.Backend.EFT.ItemEvents.Controllers
{
    public class InsureEventController : ItemEventController<InsureItemEvent>
    {
        public InsureEventController() : base("Insure")
        {
        }

        public override Task Handle(ItemEventContext context, InsureItemEvent request)
        {
            return Task.CompletedTask;
        }
    }
}
