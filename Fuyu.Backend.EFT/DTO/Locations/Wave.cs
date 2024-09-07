using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Locations
{
    [DataContract]
    public class Wave
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
        public bool isPlayers;

        [DataMember]
        public string WildSpawnType;

        // Tracks which waves to send for which game mode
        // NOTE: server-side only
        [DataMember]
        public string[] SpawnMode;
    }
}