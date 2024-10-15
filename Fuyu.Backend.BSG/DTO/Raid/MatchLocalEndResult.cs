using System.Runtime.Serialization;
using Fuyu.Backend.BSG.DTO.Profiles;

namespace Fuyu.Backend.BSG.DTO.Raid
{
    [DataContract]
    public class MatchLocalEndResult
    {
        [DataMember]
        public Profile profile;

        [DataMember]
        public string result;

        [DataMember]
        public string killerId;

        [DataMember]
        public int? killerAid;

        [DataMember]
        public string exitName;

        [DataMember]
        public bool inSession;

        [DataMember]
        public bool favorite;

        [DataMember]
        public int playTime;
    }
}