using System.Runtime.Serialization;

namespace Fuyu.Server.BSG.DTO.Profiles.Stats
{
    [DataContract]
    public class EftStats
    {
        [DataMember]
        public Counter SessionCounters;

        [DataMember]
        public Counter OverallCounters;

        [DataMember]
        public int SessionExperienceMult;

        [DataMember]
        public int ExperienceBonusMult;

        [DataMember]
        public int TotalSessionExperience;

        [DataMember]
        public long LastSessionDate;
        
        // TODO: proper type
        [DataMember]
        public object Aggressor;

        // TODO: proper type
        [DataMember]
        public object[] DroppedItems;

        // TODO: proper type
        [DataMember]
        public object[] FoundInRaidItems;

        // TODO: proper type
        [DataMember]
        public object[] Victims;

        // TODO: proper type
        [DataMember]
        public object[] CarriedQuestItems;

        [DataMember]
        public DamageHistory DamageHistory;

        // TODO: proper type
        [DataMember]
        public object LastPlayerState;

        [DataMember]
        public int TotalInGameTime;

        [DataMember]
        public string SurvivorClass;
    }
}