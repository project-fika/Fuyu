using Fuyu.Backend.EFT.DTO.Responses;
using Fuyu.Backend.EFT.ItemEvents.Models;
using Fuyu.Common.Networking;
using System.Threading.Tasks;

namespace Fuyu.Backend.EFT.ItemEvents.Controllers
{
    public class SellAllFromSavageEventController : ItemEventController<SellAllFromSavageItemEvent>
    {
        public SellAllFromSavageEventController() : base("SellAllFromSavage")
        {
        }

        public override Task Handle(ItemEventContext context, SellAllFromSavageItemEvent request)
        {
            return Task.CompletedTask;
        }
    }
}
