using System.Runtime.Serialization;
using Fuyu.Backend.BSG.DTO.Common;

namespace Fuyu.Backend.BSG.DTO.Items
{
    [DataContract]
    public class MapMarker
    {
        [DataMember]
        public EMapMarkerType Type;
        
        [DataMember]
        public int X;

        [DataMember]
        public int Y;

        [DataMember]
        public string Note;
    }
}