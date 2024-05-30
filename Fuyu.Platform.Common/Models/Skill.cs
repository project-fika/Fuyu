using System.Runtime.Serialization;
using Fuyu.Platform.Common.Models.EFT;
using Newtonsoft.Json.Converters;

namespace Fuyu.Platform.Common.Models
{
    [DataContract]
    public struct Skill
    {
        [DataMember]
        [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))] 
        public ESkillId Id;

        [DataMember]
        public int Progress;

        [DataMember]
        public int PointsEarnedDuringSession;

        [DataMember]
        public long LastAccess;
    }
}