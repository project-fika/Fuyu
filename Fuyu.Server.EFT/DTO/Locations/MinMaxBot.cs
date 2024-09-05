using System.Runtime.Serialization;

namespace Fuyu.Server.EFT.DTO.Locations
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