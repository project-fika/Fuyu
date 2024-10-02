using Fuyu.Backend.EFT.DTO.Responses;
using Fuyu.Backend.EFT.ItemEvents.Models;
using Fuyu.Common.Networking;
using System.Threading.Tasks;

namespace Fuyu.Backend.EFT.ItemEvents.Controllers
{
    public class InterGameTransferEventController : ItemEventController<InterGameTransferItemEvent>
    {
        public InterGameTransferEventController() : base("InterGameTransfer")
        {
        }

        public override Task Handle(ItemEventContext context, InterGameTransferItemEvent request)
        {
            return Task.CompletedTask;
        }
    }
}
