using System.Runtime.Serialization;

namespace Fuyu.Server.EFT.DTO.Requests
{
    [DataContract]
    public class MatchLocalStartRequest
    {
        [DataMember]
        public string location;

        [DataMember]
        public string timeVariant;

        [DataMember]
        public string mode;

        [DataMember]
        public string playerSide;
    }
}