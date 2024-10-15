using System.Runtime.Serialization;

namespace Fuyu.Backend.BSG.DTO.Multiplayer
{
    [DataContract]
    public class ProfileStatusInfo
    {
        [DataMember]
        public string profileid;

        [DataMember]
        public string profileToken;

        [DataMember]
        public string status;

        [DataMember]
        public string sid;

        [DataMember]
        public string ip;

        [DataMember]
        public int port;
    }
}