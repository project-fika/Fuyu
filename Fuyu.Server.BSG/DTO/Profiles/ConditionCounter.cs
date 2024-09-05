using System.Runtime.Serialization;

namespace Fuyu.Server.BSG.DTO.Profiles
{
    [DataContract]
    public class ConditionCounter
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