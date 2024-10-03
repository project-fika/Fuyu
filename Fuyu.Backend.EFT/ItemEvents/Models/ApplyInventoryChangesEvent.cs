using Fuyu.Backend.EFT.DTO.Items;
using Fuyu.Common.Hashing;
using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.ItemEvents.Models
{
    [DataContract]
    public class ApplyInventoryChangesEvent : BaseItemEvent
    {
        [DataMember(Name = "changedItems")]
        public ChangedItem[] ChangedItems { get; set; }
    }

    [DataContract]
    public class ChangedItem : BaseItemEvent
    {
        [DataMember(Name = "_id")]
        public MongoId Id { get; set; }

        [DataMember(Name = "_tpl")]
        public MongoId TemplateId { get; set; }

        [DataMember(Name = "parentId")]
        public MongoId? ParentId { get; set; }

        [DataMember(Name = "slotId")]
        public string Slot { get; set; }

        [DataMember(Name = "location")]
        public ItemLocation Location { get; set; }

        // It is declared in the assembly but I haven't had it sent yet
        /*        [DataMember(Name = "")]
                public ItemUpdatable Upd { get; set; }*/
    }
}
