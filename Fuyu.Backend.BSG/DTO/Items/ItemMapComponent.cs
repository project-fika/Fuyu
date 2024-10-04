using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Items
{
    [DataContract]
    public class ItemMapComponent
    {
        [DataMember]
        public List<MapMarker> Markers;
    }
}