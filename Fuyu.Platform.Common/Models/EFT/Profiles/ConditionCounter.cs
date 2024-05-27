using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Profiles
{
    [DataContract]
    public struct ConditionCounter
    {
        [DataMember]
        public string id;

        [DataMember]
        public string sourceId;

        [DataMember]
        public string type;

        [DataMember]
        public int value;
    }
}