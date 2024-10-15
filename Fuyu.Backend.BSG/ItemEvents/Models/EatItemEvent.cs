using System.Runtime.Serialization;
using Fuyu.Common.Hashing;

namespace Fuyu.Backend.BSG.ItemEvents.Models
{
    [DataContract]
    public class EatItemEvent : BaseItemEvent
    {
        [DataMember(Name = "item")]
        public MongoId Item { get; set; }

        [DataMember(Name = "count")]
        public int Count { get; set; }

        [DataMember(Name = "time")]
        public long Timestamp { get; set; }
    }
}
