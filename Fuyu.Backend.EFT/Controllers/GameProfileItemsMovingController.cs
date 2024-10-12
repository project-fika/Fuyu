using Fuyu.Backend.BSG.DTO.Responses;
using Fuyu.Backend.BSG.ItemEvents;
using Fuyu.Backend.EFT.ItemEvents.Controllers;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace Fuyu.Backend.EFT.Controllers
{
    public class GameProfileItemsMovingController : HttpController
    {
        private ItemEventRouter _router = new ItemEventRouter();

        public GameProfileItemsMovingController() : base("^/client/game/profile/items/moving$")
        {
            _router.AddController<CustomizationBuyEventController>();
            _router.AddController<EatItemEventController>();
            _router.AddController<InsureEventController>();
            _router.AddController<InterGameTransferEventController>();
            _router.AddController<MoveItemEventController>();
            _router.AddController<ReadEncyclopediaEventController>();
            _router.AddController<SellAllFromSavageEventController>();
            _router.AddController<TraderRepairEventController>();
            _router.AddController<TradingConfirmEventController>();
            _router.AddController<ApplyInventoryChangesItemEventController>();
        }

        public override async Task RunAsync(HttpContext context)
		{
			var sessionId = context.GetSessionId();
			var requestText = await context.GetTextAsync();
            var requestObject = JObject.Parse(requestText);
            var requestData = requestObject.Value<JArray>("data");
            var response = new ItemEventResponse
            {
                ProfileChanges = [],
                InventoryWarnings = []
            };

            foreach (var itemRequest in requestData)
            {
                var action = itemRequest.Value<string>("Action");
                var itemEventContext = new ItemEventContext(sessionId, action, itemRequest, response);
                await _router.RouteAsync(itemEventContext);
			}

            await context.SendJsonAsync(Json.Stringify(new ResponseBody<ItemEventResponse>
            {
                data = response
            }));
        }
    }
}
