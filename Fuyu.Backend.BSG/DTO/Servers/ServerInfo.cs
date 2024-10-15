using System.Runtime.Serialization;

namespace Fuyu.Backend.BSG.DTO.Servers
{
    [DataContract]
    public class ServerInfo
    {
        [DataMember]
        public string ip;

        [DataMember]
        public int port;
    }
}