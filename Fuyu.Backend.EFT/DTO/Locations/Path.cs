using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Locations
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