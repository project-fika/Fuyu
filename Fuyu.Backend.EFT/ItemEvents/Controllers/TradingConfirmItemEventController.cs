using Fuyu.Backend.EFT.DTO.Responses;
using Fuyu.Backend.EFT.ItemEvents.Models;
using Fuyu.Common.Networking;
using System.Threading.Tasks;

namespace Fuyu.Backend.EFT.ItemEvents.Controllers
{
    public class TradingConfirmEventController : ItemEventController<TradingConfirmItemEvent>
    {
        public TradingConfirmEventController() : base("TradingConfirm")
        {
        }

        public override Task RunAsync(ItemEventContext context, TradingConfirmItemEvent request)
        {
            return Task.CompletedTask;
        }
    }
}
