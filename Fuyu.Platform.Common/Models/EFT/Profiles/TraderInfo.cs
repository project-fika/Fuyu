using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Profiles
{
    [DataContract]
    public struct TraderInfo
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