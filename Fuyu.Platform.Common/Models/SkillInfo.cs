using System.Runtime.Serialization;
using Fuyu.Platform.Common.Models.EFT.Hideout;

namespace Fuyu.Platform.Common.Models
{
    [DataContract]
    public struct SkillInfo
    {
        [DataMember]
        public Skill[] Common;

        [DataMember]
        public Mastery[] Mastering;

        [DataMember]
        public Bonuses[] Bonuses;
        
        [DataMember]
        public int? Points;
    }
}