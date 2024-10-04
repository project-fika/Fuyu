using Fuyu.Backend.BSG.DTO.Common;
using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Items
{
    [DataContract]
    public class LocationInGrid
    {
        [DataMember]
        public int x;

        [DataMember]
        public int y;

        [DataMember]
        public EItemRotation r;

        // emits when 'false'
        [DataMember(EmitDefaultValue = false)]
        public bool isSearched;

        public override string ToString()
        {
            return $"{x},{y}:{r}|{(isSearched ? 's' : 'u')}";
        }
    }
    
    public enum EItemRotation
    {
        Horizontal,
        Vertical
    }
}