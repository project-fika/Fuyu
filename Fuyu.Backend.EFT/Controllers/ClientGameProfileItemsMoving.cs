using Fuyu.Backend.BSG.DTO.Responses;
using Fuyu.Backend.EFT.DTO.Responses;
using Fuyu.Backend.EFT.ItemEvents;
using Fuyu.Backend.EFT.ItemEvents.Controllers;
using Fuyu.Common.Collections;
using Fuyu.Common.IO;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Newtonsoft.Json.Linq;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fuyu.Backend.EFT.Controllers
{
    public class ClientGameProfileItemsMoving : HttpController
    {
        private ItemEventRouter _router = new ItemEventRouter();

        public ClientGameProfileItemsMoving() : base("/client/game/profile/items/moving")
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
        }

        public override async Task RunAsync(HttpContext context)
        {
            var requestText = await context.GetTextAsync();
            var requestObject = JObject.Parse(requestText);
            Terminal.WriteLine($"requestObject:{requestObject}");
            var requestData = requestObject.Value<JArray>("data");
            var response = new ItemEventResponse
            {
                ProfileChanges = [],
                InventoryWarnings = []
            };

            var sessionId = context.GetSessionId();
            var tasks = new List<Task>(requestData.Count);
            foreach (var itemRequest in requestData)
            {
                var action = itemRequest.Value<string>("Action");
                var itemEventContext = new ItemEventContext(sessionId, action, itemRequest, response);
                tasks.Add(_router.RouteEvent(itemEventContext));
            }

            await Task.WhenAll(tasks);
            await context.SendJsonAsync(Json.Stringify(new ResponseBody<ItemEventResponse>
            {
                data = response
            }));
        }
    }
}
