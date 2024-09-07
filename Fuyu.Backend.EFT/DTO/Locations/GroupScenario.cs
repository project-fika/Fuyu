using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Locations
{
    [DataContract]
    public class GroupScenario
    {
        [DataMember]
        public int MinToBeGroup;

        [DataMember]
        public int MaxToBeGroup;

        [DataMember]
        public int Chance;

        [DataMember]
        public bool Enabled;
    }
}