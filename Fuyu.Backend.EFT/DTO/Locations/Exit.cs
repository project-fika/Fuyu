using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Locations
{
    [DataContract]
    public class Exit
    {
        [DataMember]
        public string Name;

        [DataMember]
        public string EntryPoints;

        [DataMember]
        public int Chance;

        [DataMember]
        public int MinTime;

        [DataMember]
        public int MaxTime;

        [DataMember]
        public int PlayersCount;

        [DataMember]
        public int ExfiltrationTime;

        [DataMember(EmitDefaultValue = false)]
        public string PassageRequirement;

        [DataMember(EmitDefaultValue = false)]
        public string ExfiltrationType;

        [DataMember(EmitDefaultValue = false)]
        public string RequiredSlot;

        [DataMember]
        public string Id;

        [DataMember(EmitDefaultValue = false)]
        public string RequirementTip;

        [DataMember]
        public int Count;

        [DataMember]
        public bool EventAvailable;

        [DataMember]
        public int MinTimePVE;

        [DataMember]
        public int MaxTimePVE;

        [DataMember]
        public int ChancePVE;

        [DataMember]
        public int CountPVE;

        [DataMember]
        public int ExfiltrationTimePVE;

        [DataMember]
        public int PlayersCountPVE;
    }
}