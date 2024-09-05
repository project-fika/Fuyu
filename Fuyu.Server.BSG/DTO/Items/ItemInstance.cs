using System.Runtime.Serialization;

namespace Fuyu.Server.EFT.DTO.Items
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
        public ItemLocation location;

        // emits when 'null'
        [DataMember(EmitDefaultValue = true)]
        public ItemUpdatable upd;
    }
}