using Fuyu.Common.Hashing;
using Fuyu.Backend.BSG.ItemEvents.Models;
using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.ItemEvents.Models
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
