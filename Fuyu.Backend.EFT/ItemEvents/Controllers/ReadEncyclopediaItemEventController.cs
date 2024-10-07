using Fuyu.Backend.BSG.ItemEvents;
using Fuyu.Backend.EFT.DTO.Responses;
using Fuyu.Backend.EFT.ItemEvents.Models;
using Fuyu.Backend.BSG.ItemEvents.Controllers;
using Fuyu.Common.Networking;
using System.Threading.Tasks;

namespace Fuyu.Backend.EFT.ItemEvents.Controllers
{
    public class ReadEncyclopediaEventController : ItemEventController<ReadEncyclopediaItemEvent>
    {
        public ReadEncyclopediaEventController() : base("ReadEncyclopedia")
        {
        }

        public override Task RunAsync(ItemEventContext context, ReadEncyclopediaItemEvent request)
        {
            return Task.CompletedTask;
        }
    }
}
