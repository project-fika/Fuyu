using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Locations
{
    [DataContract]
    public struct MinMaxBot
    {
        [DataMember]
        public int min;

        [DataMember]
        public int max;

        [DataMember]
        public string WildSpawnType;
    }
}