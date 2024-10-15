using System.Runtime.Serialization;

namespace Fuyu.Backend.BSG.DTO.Responses
{
    [DataContract]
    public class GameKeepaliveResponse
    {
        [DataMember]
        public string msg;

        [DataMember]
        public double utc_time;
    }
}