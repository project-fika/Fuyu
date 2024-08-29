using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Multiplayer
{
    [DataContract]
    public struct ProfileStatusInfo
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