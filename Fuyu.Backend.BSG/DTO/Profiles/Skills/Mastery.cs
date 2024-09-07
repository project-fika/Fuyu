using System.Runtime.Serialization;

namespace Fuyu.Backend.BSG.DTO.Profiles.Skills
{
    [DataContract]
    public class Mastery
    {
        [DataMember] 
        public string Id;

        [DataMember]
        public int Progress;
    }
}