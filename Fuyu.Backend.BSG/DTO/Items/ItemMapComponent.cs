using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Fuyu.Backend.BSG.DTO.Items
{
    [DataContract]
    public class ItemMapComponent
    {
        [DataMember]
        public List<MapMarker> Markers;
    }
}