using System.Runtime.Serialization;
using Fuyu.Platform.Common.Models.EFT.Items;

namespace Fuyu.Platform.Common.Models
{
    [DataContract]
    public struct ItemInstance
    {
        [DataMember]
        public string _id;

        [DataMember]
        public string _tpl;

        // emits when 'null'
        [DataMember(EmitDefaultValue = false)]
        public string parentId;

        // emits when 'null'
        [DataMember(EmitDefaultValue = false)]
        public string slotId;

        // emits when 'null'
        [DataMember(EmitDefaultValue = false)]
        public ItemLocation? location;

        // emits when 'null'
        [DataMember(EmitDefaultValue = false)]
        public ItemUpdatable? upd;
    }
}