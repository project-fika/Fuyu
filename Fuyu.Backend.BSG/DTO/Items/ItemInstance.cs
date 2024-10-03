using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Items
{
    [DataContract]
    public class ItemInstance
    {
        [DataMember]
        public string _id;

        [DataMember]
        public string _tpl;

        // emits when 'null'
        [DataMember(EmitDefaultValue = true)]
        public string parentId;

        // emits when 'null'
        [DataMember(EmitDefaultValue = true)]
        public string slotId;

        // emits when 'null'
        [DataMember(EmitDefaultValue = true)]
        public LocationInGrid location;

        // emits when 'null'
        [DataMember(EmitDefaultValue = false)]
        public ItemUpdatable upd;
    }
}