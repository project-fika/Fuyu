using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Servers
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