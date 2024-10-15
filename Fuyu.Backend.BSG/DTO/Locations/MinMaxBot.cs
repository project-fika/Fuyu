using System.Runtime.Serialization;

namespace Fuyu.Backend.BSG.DTO.Locations
{
    [DataContract]
    public class MinMaxBot
    {
        [DataMember]
        public int min;

        [DataMember]
        public int max;

        [DataMember]
        public string WildSpawnType;
    }
}