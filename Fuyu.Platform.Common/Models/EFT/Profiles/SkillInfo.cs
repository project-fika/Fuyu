using System.Runtime.Serialization;
using Fuyu.Platform.Common.Models.EFT.Profiles.Skills;

namespace Fuyu.Platform.Common.Models.EFT.Profiles
{
    [DataContract]
    public struct SkillInfo
    {
        [DataMember]
        public Skill[] Common;

        [DataMember]
        public Mastery[] Mastering;

        [DataMember]
        public int Points;
    }
}