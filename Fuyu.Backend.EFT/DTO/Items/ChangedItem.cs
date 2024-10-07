using Fuyu.Backend.BSG.ItemEvents.Models;
using Fuyu.Common.Hashing;
using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Items
{
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
        public LocationInGrid Location { get; set; }

        // SKIPPED: Upd
        // Reason: it is declared in the assembly but I haven't had it sent yet
        // -- nexus4880, 2024-10-07
        // [DataMember(Name = "upd")]
        // public ItemUpdatable Upd { get; set; }*/
    }
}
