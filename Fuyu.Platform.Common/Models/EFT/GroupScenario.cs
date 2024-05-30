using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT
{
    [DataContract]
    public struct GroupScenario
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