using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Locations
{
    [DataContract]
    public struct WorldMap
    {
        [DataMember]
        public Dictionary<string, Location> locations;

        [DataMember]
        public Path[] paths;
    }
}