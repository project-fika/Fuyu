using System.Runtime.Serialization;
using Newtonsoft.Json.Converters;

namespace Fuyu.Backend.BSG.DTO.Profiles.Skills
{
    [DataContract]
    public class Skill
    {
        [DataMember]
        [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))] 
        public ESkillType Id;

        [DataMember]
        public int Progress;

        [DataMember]
        public int PointsEarnedDuringSession;

        [DataMember]
        public long LastAccess;
    }
}