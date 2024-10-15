using System.Runtime.Serialization;

namespace Fuyu.Backend.BSG.DTO.Responses
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