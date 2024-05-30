using System.Runtime.Serialization;
using Fuyu.Platform.Common.Models.EFT;
using Fuyu.Platform.Common.Models.EFT.Locations;

namespace Fuyu.Platform.Common.Models
{
    [DataContract]
    public struct BossSpawn
    {
        [DataMember]
        public string BossName;

        [DataMember]
        public int BossChance;

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

        [DataMember]
        public string TriggerId;

        [DataMember]
        public string TriggerName;

        [DataMember(EmitDefaultValue = false)]
        public WildSpawnSupports[] Supports;

        [DataMember]
        public bool RandomTimeSpawn;

        [DataMember(EmitDefaultValue = false)]
        public int Delay;

        [DataMember(EmitDefaultValue = false)]
        public bool ForceSpawn;

        [DataMember(EmitDefaultValue = false)]
        public bool IgnoreMaxBots;
    }
}