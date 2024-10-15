using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Fuyu.Backend.BSG.DTO.Locations
{
    [DataContract]
    public class WorldMap
    {
        [DataMember]
        public Dictionary<string, Location> locations;

        [DataMember]
        public Path[] paths;
    }
}