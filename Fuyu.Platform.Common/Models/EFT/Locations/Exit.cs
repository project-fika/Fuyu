using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Locations
{
    [DataContract]
    public struct Exit
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

        [DataMember(EmitDefaultValue = false)]
        public int? Count;

        [DataMember]
        public bool EventAvailable;
    }
}