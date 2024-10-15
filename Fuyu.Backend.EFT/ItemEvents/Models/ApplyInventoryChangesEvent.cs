using Fuyu.Backend.BSG.ItemEvents.Models;
using Fuyu.Backend.EFT.DTO.Items;
using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.ItemEvents.Models
{
    [DataContract]
    public class ApplyInventoryChangesEvent : BaseItemEvent
    {
        [DataMember(Name = "changedItems")]
        public ItemInstance[] ChangedItems { get; set; }
    }
}
