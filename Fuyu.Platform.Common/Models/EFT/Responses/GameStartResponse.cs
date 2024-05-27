using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Responses
{
    [DataContract]
    public struct GameStartResponse
    {
        [DataMember]
        public double utc_time;
    }
}