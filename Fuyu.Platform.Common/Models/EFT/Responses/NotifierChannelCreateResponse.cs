using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Responses
{
    [DataContract]
    public struct NotifierChannelCreateResponse
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