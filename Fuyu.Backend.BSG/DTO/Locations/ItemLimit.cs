using System.Runtime.Serialization;

namespace Fuyu.Backend.BSG.DTO.Locations
{
    [DataContract]
    public class ItemLimit
    {
        [DataMember]
        public string[] items;

        [DataMember]
        public int min;

        [DataMember]
        public int max;
    }
}