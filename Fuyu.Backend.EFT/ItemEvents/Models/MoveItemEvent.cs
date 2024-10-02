using Fuyu.Backend.EFT.DTO.Items;
using Fuyu.Common.Hashing;
using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.ItemEvents.Models
{
    [DataContract]
    public class MoveItemEvent : BaseItemEvent
    {
        [DataMember(Name = "item")]
        public MongoId Item { get; set; }

        [DataMember(Name = "to")]
        public To To { get; set; }
    }

    [DataContract]
    public class To
    {
        [DataMember(Name = "id")]
        public MongoId Id { get; set; }

        [DataMember(Name = "container")]
        public string Container { get; set; }

        [DataMember(Name = "location")]
        public ItemLocation Location { get; set; }
    }
}
