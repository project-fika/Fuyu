using System.Runtime.Serialization;

namespace Fuyu.Backend.BSG.DTO.Profiles
{
    [DataContract]
    public class TraderInfo
    {
        [DataMember]
        public bool unlocked;

        [DataMember]
        public bool disabled;

        [DataMember]
        public int salesSum;

        [DataMember]
        public float standing;
    }
}