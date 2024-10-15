using System.Runtime.Serialization;
using Fuyu.Backend.BSG.DTO.Items;

namespace Fuyu.Backend.BSG.ItemEvents.Models
{
    [DataContract]
    public class ApplyInventoryChangesEvent : BaseItemEvent
    {
        [DataMember(Name = "changedItems")]
        public ChangedItem[] ChangedItems { get; set; }
    }
}
