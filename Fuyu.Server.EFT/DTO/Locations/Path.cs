using System.Runtime.Serialization;

namespace Fuyu.Server.EFT.DTO.Locations
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