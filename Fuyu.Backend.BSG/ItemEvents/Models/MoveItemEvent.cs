using System.Runtime.Serialization;
using Fuyu.Backend.BSG.DTO.Items;
using Fuyu.Common.Hashing;

namespace Fuyu.Backend.BSG.ItemEvents.Models
{
    [DataContract]
    // There is more data to this I have not needed it so I have not added it yet
    public class MoveItemEvent : BaseItemEvent
    {
        [DataMember(Name = "item")]
        public MongoId Item { get; set; }

        [DataMember(Name = "to")]
        public RelocateTarget To { get; set; }
    }

    [DataContract]
    public class RelocateTarget
    {
        [DataMember(Name = "id")]
        public MongoId Id { get; set; }

        [DataMember(Name = "container")]
        public string Container { get; set; }

        [DataMember(Name = "location")]
        public LocationInGrid Location { get; set; }
    }
}
