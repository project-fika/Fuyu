using Newtonsoft.Json.Linq;
using Fuyu.Backend.BSG.DTO.Responses;
using Fuyu.Common.Networking;

namespace Fuyu.Backend.BSG.ItemEvents
{
    public class ItemEventContext : IRouterContext
    {
        public string SessionId { get; }
        public string Action { get; }
        public JToken Data { get; }
        public ItemEventResponse Response { get; }

        public ItemEventContext(string sessionId, string action, JToken data, ItemEventResponse response)
        {
            SessionId = sessionId;
            Action = action;
            Data = data;
            Response = response;
        }

        public T GetData<T>()
        {
            return Data.ToObject<T>();
        }
    }
}
