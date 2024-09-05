using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Items
{
    [DataContract]
    public class ItemLocation
    {
        [DataMember]
        public int x;

        [DataMember]
        public int y;

        [DataMember]
        public int r;

        // emits when 'false'
        [DataMember(EmitDefaultValue = false)]
        public bool isSearched;
    }
}