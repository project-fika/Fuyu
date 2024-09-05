using System.Runtime.Serialization;

namespace Fuyu.Server.BSG.DTO.Profiles.Skills
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