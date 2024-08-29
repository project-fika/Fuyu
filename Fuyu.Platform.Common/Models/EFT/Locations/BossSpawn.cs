using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Locations
{
    [DataContract]
    public struct BossSpawn
    {
        [DataMember]
        public string BossName;

        [DataMember]
        public int BossChance;

        [DataMember]
        public string BossZone;

        [DataMember]
        public bool BossPlayer;

        [DataMember]
        public string BossDifficult;

        [DataMember]
        public string BossEscortType;

        [DataMember]
        public string BossEscortDifficult;

        [DataMember]
        public string BossEscortAmount;

        [DataMember]
        public int Time;

        [DataMember(EmitDefaultValue = false)]
        public BossSupport[] Supports;

        [DataMember]
        public bool RandomTimeSpawn;

        [DataMember(EmitDefaultValue = false)]
        public bool ForceSpawn;

        [DataMember(EmitDefaultValue = false)]
        public bool IgnoreMaxBots;

        [DataMember]
        public string TriggerName;

        [DataMember]
        public string TriggerId;

        [DataMember(EmitDefaultValue = false)]
        public int Delay;

        // NOTE: server-side only
        [DataMember]
        public string[] SpawnMode;
    }
}