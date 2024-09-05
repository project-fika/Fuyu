using System.Runtime.Serialization;
using Fuyu.Server.BSG.DTO.Profiles.Skills;

namespace Fuyu.Server.BSG.DTO.Profiles
{
    [DataContract]
    public class SkillInfo
    {
        [DataMember]
        public Skill[] Common;

        [DataMember]
        public Mastery[] Mastering;

        [DataMember]
        public int Points;
    }
}