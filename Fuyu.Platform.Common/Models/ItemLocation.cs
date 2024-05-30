using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models
{
    [DataContract]
    public struct ItemLocation
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