using Fuyu.Backend.BSG.DTO.Common;
using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Items
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