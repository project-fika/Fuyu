using System.Runtime.Serialization;

namespace Fuyu.Server.Arena.DTO.Servers
{
    [DataContract]
    public class ServerInfo
    {
        [DataMember]
        public string Ip;

        [DataMember]
        public string DataCenter;

        [DataMember]
        public int Port;

        [DataMember]
        public bool IsSelected;

        [DataMember]
        public bool Hidden;
    }
}