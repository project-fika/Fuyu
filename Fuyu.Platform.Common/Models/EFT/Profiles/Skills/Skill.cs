using System.Runtime.Serialization;
using Newtonsoft.Json.Converters;

namespace Fuyu.Platform.Common.Models.EFT.Profiles.Skills
{
    [DataContract]
    public struct Skill
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