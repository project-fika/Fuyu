using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Locations
{
    [DataContract]
    public struct Wave
    {
        [DataMember]
        public int number;

        [DataMember]
        public int time_min;

        [DataMember]
        public int time_max;

        [DataMember]
        public int slots_min;

        [DataMember]
        public int slots_max;

        [DataMember]
        public string SpawnPoints;

        [DataMember]
        public string BotSide;

        [DataMember]
        public string BotPreset;

        [DataMember]
        public string WildSpawnType;

        [DataMember]
        public bool isPlayers;
    }
}