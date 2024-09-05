using System.Runtime.Serialization;

namespace Fuyu.Server.Arena.DTO.Responses
{
    [DataContract]
    public class NotifierChannelCreateResponse
    {
        [DataMember]
        public string server;

        [DataMember]
        public string channel_id;

        [DataMember]
        public string url;

        [DataMember]
        public string notifierServer;

        [DataMember]
        public string ws;
    }
}