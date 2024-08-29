using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Responses
{
    [DataContract]
    public struct GameProfileCreateResponse
    {
        [DataMember]
        public string uid;
    }
}