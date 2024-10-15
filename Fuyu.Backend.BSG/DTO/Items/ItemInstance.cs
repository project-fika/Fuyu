using System.Runtime.Serialization;
using Fuyu.Common.Collections;
using Fuyu.Common.Hashing;

namespace Fuyu.Backend.EFT.DTO.Items
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
        public MongoId? parentId;

        // emits when 'null'
        [DataMember(EmitDefaultValue = false)]
        public string slotId;

        // emits when 'null'
        [DataMember(EmitDefaultValue = false)]
        public Union<LocationInGrid, int> location;

        // emits when 'null'
        [DataMember(EmitDefaultValue = false)]
        public ItemUpdatable upd;
    }
}