using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Responses
{
    [DataContract]
    public struct Backends
    {
        [DataMember]
        public string Lobby;

        [DataMember]
        public string Trading;

        [DataMember]
        public string Messaging;

        [DataMember]
        public string Main;

        [DataMember]
        public string RagFair;
    }
}