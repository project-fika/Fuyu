using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Responses
{
    [DataContract]
    public struct GameKeepaliveResponse
    {
        [DataMember]
        public string msg;

        [DataMember]
        public double utc_time;
    }
}