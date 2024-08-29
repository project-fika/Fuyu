using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Requests
{
    [DataContract]
    public struct MatchLocalStartRequest
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