using System.Runtime.Serialization;
using Fuyu.Platform.Common.Models.EFT.Profiles;
using Fuyu.Platform.Common.Models.EFT.Profiles.Stats;
using DroppedItem = Fuyu.Platform.Common.Models.EFT.DroppedItem;
using FoundInRaidItem = Fuyu.Platform.Common.Models.EFT.FoundInRaidItem;

namespace Fuyu.Platform.Common.Models.EFT
{
    [DataContract]
    public struct EftStats
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
        
        [DataMember]
        public AggressorStats Aggressor;

        [DataMember]
        public DroppedItem[] DroppedItems;

        [DataMember]
        public FoundInRaidItem[] FoundInRaidItems;

        [DataMember]
        public VictimStats[] Victims;

        [DataMember]
        public string[] CarriedQuestItems;

        [DataMember]
        public DamageHistory DamageHistory;

        [DataMember]
        public PlayerVisualRepresentation LastPlayerState;

        [DataMember]
        public int TotalInGameTime;

        [DataMember]
        public string SurvivorClass;
    }
}