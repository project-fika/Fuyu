using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Servers
{
    [DataContract]
    public struct ServerInfo
    {
        [DataMember]
        public string ip;

        [DataMember]
        public int port;
    }
}