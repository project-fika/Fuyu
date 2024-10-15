using System.Runtime.Serialization;

namespace Fuyu.Backend.BSG.DTO.Locations
{
    [DataContract]
    public class Path
    {
        [DataMember]
        public string Source;

        [DataMember]
        public string Destination;
    }
}