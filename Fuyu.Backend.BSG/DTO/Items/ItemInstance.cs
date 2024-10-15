using System.Runtime.Serialization;
using Fuyu.Common.Hashing;

namespace Fuyu.Backend.BSG.DTO.Items
{
    [DataContract]
    public class ItemInstance
    {
        [DataMember]
        public MongoId _id;

        [DataMember]
        public MongoId _tpl;

        // emits when 'null'
        [DataMember(EmitDefaultValue = false)]
        public MongoId parentId;

        // emits when 'null'
        [DataMember(EmitDefaultValue = false)]
        public string slotId;

        // emits when 'null'
        [DataMember(EmitDefaultValue = false)]
        public LocationInGrid location;

        // emits when 'null'
        [DataMember(EmitDefaultValue = false)]
        public ItemUpdatable upd;
    }
}