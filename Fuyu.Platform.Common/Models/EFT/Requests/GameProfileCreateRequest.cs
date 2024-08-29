using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Requests
{
    [DataContract]
    public struct GameProfileCreateRequest
    {
        [DataMember]
        public string side;

        [DataMember]
        public string nickname;

        [DataMember]
        public string headId;

        [DataMember]
        public string voiceId;
    }
}